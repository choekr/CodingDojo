from __future__ import unicode_literals

from django.db import models
from ..login_reg.models import User

class CourseManager(models.Manager):
  def user_course_pair(self, data):
    course = self.get(id=data['course'])

    user = User.objects.get(id=data['user'])

    course.user.add(user)

    course.save()
    
class Course(models.Model):
  name = models.CharField(max_length=255)
  description = models.TextField(max_length=2000)
  user = models.ManyToManyField(User, related_name = 'users')
  created_at = models.DateTimeField(auto_now_add=True)
  updated_at = models.DateTimeField(auto_now=True)
  objects = CourseManager()


# Create your models here.
