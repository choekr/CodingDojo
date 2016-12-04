from django.shortcuts import render, redirect
# from time import strftime
from datetime import datetime
from django.core.urlresolvers import reverse


# Create your views here.
def index(request):
  if 'user' not in request.session:
    return redirect("login_reg:index")
    
  currentTime = {
  "CurrentTime": datetime.now()
  }
  return render(request, 'timedisplay/index.html', currentTime)
