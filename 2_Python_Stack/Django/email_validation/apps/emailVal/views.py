from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Email

# Create your views here.
def index (request):

  return render(request, "emailVal/index.html")

def process(request):
  res = Email.objects.add_email(request.POST)

  if res["added"]:
    messages.success(request, "The email address you entered ({}) is a VALID email address! Thank you!".format(res['new_email'].email))
    return redirect("success")

  else:
    for error in res["errors"]:
      messages.error(request, error)
    return redirect('/')


def success(request):
  context = {
    "emails": Email.objects.all()
  }
  return render(request, 'emailVal/success.html', context)

def remove(request, id):
  Email.objects.get(id=id).delete()
  return redirect("success")
