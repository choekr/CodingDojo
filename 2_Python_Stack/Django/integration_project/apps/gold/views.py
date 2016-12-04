from django.shortcuts import render, redirect
import random, time, pytz
from datetime import datetime
from pytz import timezone
from tzlocal import get_localzone
from django.core.urlresolvers import reverse

# Create your views here.
def index(request):
  if 'user' not in request.session:
    return redirect("login_reg:index")
    
  if 'myGold' not in request.session:
    request.session['myGold'] = 0

  if 'activityLog' not in request.session:
    request.session['activityLog'] = []
  return render(request, 'gold/index.html')

def process_money(request):

  local_tz = get_localzone()
  ts = time.time()
  utc_now= datetime.utcfromtimestamp(ts)
  local_now = utc_now.replace(tzinfo=pytz.utc).astimezone(local_tz)
  request.session['time'] = local_now.strftime('%b %-d, %Y at %-I:%M:%S %p')



  building = request.POST['building']
  
  if building == 'Farm':
    newGold = random.randint(10,20)
    request.session['myGold'] += newGold
  if building == 'Cave':
    newGold = random.randint(5,10)
    request.session['myGold'] += newGold
  if building == 'House':
    newGold = random.randint(2,5)
    request.session['myGold'] += newGold
  if building == 'Casino':
    newGold = random.randint(-50,50)
    request.session['myGold'] += newGold
  
  activity = {
    'activity': 'You {} {} {} from the {}: Logged at {}'.format('earned' if newGold>0 else 'lost', abs(newGold), 'gold' if 0 <= newGold <= 1 else 'golds', building, request.session['time']),
    'color': 'green' if newGold>0 else 'red',
  }
  request.session['activityLog'].insert(0,activity)

  return redirect(reverse('gold:index'))

def reset(request):
  request.session.clear()
  return redirect(reverse('gold:index'))


# def clearActivity(request):
#   request.session['activityLog']
