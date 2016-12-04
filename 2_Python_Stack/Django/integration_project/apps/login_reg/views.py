from django.shortcuts import render, redirect
from django.contrib import messages
import re
from datetime import datetime
from .models import User
from django.core.urlresolvers import reverse
from django.contrib.auth import logout

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
    request.session['user'] = res["new_user"].id
    messages.success(request, "Success! Welcome, {}!".format(res['new_user'].first_name))
    request.session['notification'] = "Registered successfully"
    return redirect("login_reg:main")

  else:
    for error in res['errors']:
      messages.error(request, error)
  return redirect('login_reg:index')

def login(request):
  user = User.objects.login(request.POST)
  if user['access']:
    request.session['user'] = user['User'].id
    messages.success(request, "Success! Welcome, {}!".format(user['User'].first_name))
    request.session['notification'] = 'Logged in successfully!'
    return redirect('login_reg:main')

  else:
    messages.error(request, 'Email/Password not found')
    return redirect('/')

def logout_process(request):
    request.session.clear()
    # logout(request)
    messages.success(request, "Successfully logged out")
    return redirect("login_reg:index")

def main(request):
  if 'user' not in request.session:
    return redirect("login_reg:index")
    
  return render(request, 'login_reg/success.html')
