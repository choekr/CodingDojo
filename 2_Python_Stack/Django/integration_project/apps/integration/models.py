from __future__ import unicode_literals

from django.db import models
from ..login_reg.models import User
# Create your models here.
class Integration(models.Model):
  creator = models.ForeignKey(User)
  created_at = models.DateField(auto_now_add=True)
  updated_at = models.DateField(auto_now=True)
