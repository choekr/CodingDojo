from django.conf.urls import url
# from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^$', views.tmnt),
    url(r'^ninja/$', views.ninja),
    url(r'^ninja/(?P<color>\w+)$', views.color)
]
