from django.conf.urls import url
from . import views
# from django.contrib import admin

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^process$', views.process, name='process'),
    url(r'^add_user$', views.add_user, name='add_user'),
    url(r'^remove/(?P<id>\d+)$', views.remove, name='remove'),
    url(r'^destroy/(?P<id>\d+)$', views.delete, name='destroy')
]
