from django.shortcuts import render, redirect
from django.contrib import messages
import re
from datetime import datetime
from .models import User

NAMES_REGEX = re.compile(r'^[a-zA-Z.+_-]+$')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
CAP_REGEX = re.compile(r'^[A-Z]+$')
NUM_REGEX = re.compile(r'^[0-9]+$')
# Create your views here.
def index(request):

  return render(request, 'login_reg/index.html')

def register(request):
  res = User.objects.register(request.POST)

  if res["added"]:
    messages.success(request, "Success! Welcome, {}!".format(res['new_user'].first_name))
    request.session['notification'] = "Registered successfully"
    return redirect("main")

  else:
    for error in res['errors']:
      messages.error(request, error)
  return redirect('index')

def login(request):
  res = User.objects.login(request.POST)
  if res['access']:
    messages.success(request, "Success! Welcome, {}!".format(res['User'].first_name))
    request.session['notification'] = 'Logged in successfully!'
    return redirect('main')

  else:
    messages.error(request, 'Email/Password not found')
    return redirect('/')

def main(request):

  return render(request, 'login_reg/success.html')
