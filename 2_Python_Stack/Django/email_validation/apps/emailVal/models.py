from __future__ import unicode_literals

from django.db import models
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

# Create your models here.
class EmailManager(models.Manager):
  def add_email(self, data):
    errors = []

    if not data['email']:
      errors.append("Enter an email!!!")
    elif not EMAIL_REGEX.match(data['email']):
      errors.append("Enter a valid email!!!")

    response = {}

    if not errors:
      new_email = self.create(email=data['email'])
      response["added"] = True
      response["new_email"] = new_email

    else: 
      response["added"] = False
      response["errors"] = errors

    return response

class Email(models.Model):
  email = models.CharField(max_length=255)
  created_at = models.DateTimeField(auto_now_add = True)
  updated_at = models.DateTimeField(auto_now = True)
  objects = EmailManager()
