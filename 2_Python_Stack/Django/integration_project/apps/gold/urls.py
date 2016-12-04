from django.conf.urls import url
from . import views
# from django.contrib import admin

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^process_money$', views.process_money, name='process_money'),
    url(r'^reset$', views.reset, name='reset')
]