from django.conf.urls import url
from . import views
# from django.contrib import admin

urlpatterns = [
    url(r'^$', views.index),
    url(r'^process$', views.process),
    url(r'^remove/(?P<id>\d+)$', views.remove),
    url(r'^destroy/(?P<id>\d+)$', views.delete)
]
