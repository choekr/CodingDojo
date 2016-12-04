from django.shortcuts import render

# Create your views here.
def tmnt(request):
  return render(request, 'puff/index.html')

def ninja(request):
  # context = {
  #   'hide': True
  # }
  group = "puff/img/tmnt.png"
  context = {
    "pic": group,
  }

  return render(request, 'puff/ninja.html', context)

def color(request, color):
  # context={
  #   'color': color,
  #   'hide': False
  # }
##Jack's way 
  colors = {
    "blue": "puff/img/leonardo.jpg",
    "orange": "puff/img/michelangelo.jpg",
    "red": "puff/img/raphael.jpg",
    "purple": "puff/img/donatello.jpg",
  }

  if color in colors:
    newcolor = colors[color]
  else:
    newcolor = "puff/img/notapril.jpg"

  context = {
    "id": color, 
    "pic": newcolor,
  }

  return render(request, 'puff/ninja.html', context)

    # {% if hide == True %}
    #   <img src= "{% static 'puff/img/tmnt.png' %}">
    # {% endif %}

    # {% if hide == False %}
    #     {% if color == 'blue' %}
    #       <img src="{% static 'puff/img/leonardo.jpg' %}">
    #     {% elif color == 'orange' %}
    #       <img src="{% static 'puff/img/michelangelo.jpg' %}">
    #     {% elif color == 'red' %}
    #       <img src="{% static 'puff/img/raphael.jpg' %}">
    #     {% elif color == 'purple' %}
    #       <img src="{% static 'puff/img/donatello.jpg' %}">
    #     {% else %}
    #       <img src="{% static 'puff/img/notapril.jpg' %}">
    #     {% endif %}
    # {% endif %}
