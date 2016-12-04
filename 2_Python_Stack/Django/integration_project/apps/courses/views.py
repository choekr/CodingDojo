from django.shortcuts import render, redirect
from django.core.urlresolvers import reverse
from django.contrib import messages
from django.db.models import Count
from .models import Course
from ..login_reg.models import User


# Create your views here.
def index(request):
  if 'user' not in request.session:
    return redirect("login_reg:index")
  context = {
    # "courses": Course.objects.all(),
    'users': User.objects.all(),
    'courses': Course.objects.annotate(user_count=Count("user"))
  }
  return render(request, "courses/index.html", context)

def process(request):
  if not request.POST['course_name']:
    messages.error(request, "Please enter a course name!")
  elif not request.POST['course_description']:
    messages.error(request, "Please enter a course description!")
  else:
    Course.objects.create(name=request.POST['course_name'], description=request.POST['course_description'])
  return redirect(reverse('courses:index'))

def add_user(request):
  Course.objects.user_course_pair(request.POST)
  return redirect(reverse('courses:index'))

def remove(request, id):
  context = {
    'remove': Course.objects.get(id=id)
  }
  return render(request, "courses/remove.html", context)

def delete(request, id):
  Course.objects.get(id=id).delete()
  return redirect(reverse('courses:index'))
