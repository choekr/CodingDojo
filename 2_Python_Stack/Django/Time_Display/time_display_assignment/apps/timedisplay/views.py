from django.shortcuts import render
# from time import strftime
from datetime import datetime

# Create your views here.
def index(request):

  currentTime = {
  "CurrentTime": datetime.now()
  }
  return render(request, 'timedisplay/index.html', currentTime)
