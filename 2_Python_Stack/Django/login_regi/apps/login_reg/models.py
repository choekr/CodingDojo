from __future__ import unicode_literals

from django.db import models
import re, bcrypt

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class UserManager(models.Manager):
  def register(self, data):

    errors = []
    response = {}

    if len(data['email' and 'first_name' and 'last_name' and 'password' and 'confirm_pw'])<1:
      errors.append("You cannot leave any field blank!")
    elif len(data['first_name'])<2:
      errors.append("First name must contain more than 2 characters")
    elif not (data['first_name']).isalpha():
      errors.append("First name can only contain letters")
    elif len(data['last_name'])<2:
      errors.append("Last name must contain more than 2 characters")
    elif not (data['last_name']).isalpha():
      errors.append("Last name can only contain letters")
    elif not EMAIL_REGEX.match(data['email']):
      errors.append("Please enter a valid E-mail address")
    elif User.objects.filter(email=data['email']):
      errors.append("Email is in use")
    elif not len(data['password'])>7:
      errors.append("Your password must contain more than 8 characters")
    elif not (data['password']==data['confirm_pw']):
      errors.append("Unable to confirm password. Please enter same password you have entered above!")

    if not errors:
      password = data['password'].encode()
      hashed = bcrypt.hashpw(password, bcrypt.gensalt())
      new_user = self.create(first_name=data['first_name'],last_name=data['last_name'], email=data['email'], password=hashed)

      response['added'] = True
      response['new_user'] = new_user

    else:
      response['added'] = False
      response['errors'] = errors
    
    print errors 

    return response

  def login(self, data):
    response={}

    user = User.objects.filter(email=data['login_email'])
    password = data['login_pw'].encode()

    if user:
      if bcrypt.hashpw(password, user[0].password.encode()) == user[0].password.encode():
        response['access'] = True
        response['User'] = user[0]
      else: 
        response['access'] = False
    else:
      response['access'] = False
    return response

class User(models.Model):
  email = models.CharField(max_length=255)
  first_name = models.CharField(max_length=255)
  last_name = models.CharField(max_length=255)
  password = models.CharField(max_length=255)
  created_at = models.DateTimeField(auto_now_add = True)
  updated_at = models.DateTimeField(auto_now = True)
  objects = UserManager()
