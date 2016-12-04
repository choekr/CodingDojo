from django.conf.urls import url
from . import views

# from django.contrib import admin

urlpatterns = [
    # url(r'^admin/', admin.site.urls),
    url(r'^$', views.index, name='index'),
    url(r'^register$', views.register, name='register'),
    url(r'^login$', views.login, name='login'),
    url(r'^main$', views.main, name='main')
]
