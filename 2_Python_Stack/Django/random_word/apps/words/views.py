from django.shortcuts import render, redirect
import string
import random

# Create your views here.

def index(request):
  try:
    request.session['counter'] += 1 
  except KeyError:
    request.session['counter'] = 1
  context = {
  "Something": ''.join(random.choice(string.ascii_uppercase + string.digits) for repeats in range(14))
  }
  return render(request, 'words/index.html', context)

def reset(request):
  del request.session['counter']
  return redirect('/')
