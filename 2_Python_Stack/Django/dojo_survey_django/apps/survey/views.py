from django.shortcuts import render, redirect

# Create your views here.
def index (request):
  return render(request, 'survey/index.html')

def result (request):
  try:
    request.session['counter'] += 1 
  except Exception:
    request.session['counter'] = 1
  if request.method == "POST":
    request.session['name1'] = request.POST['name0']
    request.session['location1'] = request.POST['location0']
    request.session['language1'] = request.POST['language0']
    request.session['comment1'] = request.POST['comment0']
    return render(request, 'survey/user_info.html')
  else:
    return redirect('/')

def user (request):

  return render(request, 'survey/user_info.html')
