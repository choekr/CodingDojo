from django.shortcuts import render, redirect
from .models import Course

# Create your views here.
def index(request):
  context = {
    "courses": Course.objects.all(),
  }
  return render (request, "courses/index.html", context)

def process(request):
  Course.objects.create(name=request.POST['name'], description=request.POST['description'])

  return redirect('/')

def remove(request, id):
  context = {
    'remove': Course.objects.get(id=id)
  }
  return render (request, "courses/remove.html", context)

def delete(request, id):
  Course.objects.get(id=id).delete()
  return redirect('/')
