from flask import Flask, flash, render_template, redirect, request, session
import random
import re
from datetime import datetime

NAMES_REGEX = re.compile(r'^[a-zA-Z.+_-]+$')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
CAP_REGEX = re.compile(r'^[A-Z]+$')
NUM_REGEX = re.compile(r'^[0-9]+$')
# DATE_REGEX = re.compile(r'^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])(19|20)\d\d[- /.]$')

today = datetime.now()

app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

@app.route('/')
def index():
  return render_template('index.html')
@app.route('/process', methods=['Post'])
def process():
  if len(request.form['email' and 'first_name' and 'last_name' and 'password' and 'confirm_password'])<1:
    flash("You cannot leave any field blank")
  elif not str.isalpha(str(request.form['first_name' and 'last_name'])):
    flash("Name cannot contain any numbers")
  elif not request.form['birth_date']:
    flash("Please enter valid date!")

  if today <= datetime.strptime(request.form['birth_date'],"%Y-%m-%d"):
    flash("Please enter a valid birth date.")
  elif not EMAIL_REGEX.match(request.form['email']):
    flash("Invalid Email Address!")
  elif len(request.form['password']) <= 8:
    flash("Password should be more than 8 characters long.")
  elif not CAP_REGEX.match(request.form['password']) or \
    not NUM_REGEX.match(request.form['password']):
    flash("Your password must contain at least one capital letter and one number!!")
  elif not request.form['password'] == request.form['confirm_password']:
    flash("Your password do not match confirmation!")


  # elif not NAMES_REGEX.match(request.form['first_name']):
  #   flash("First name cannot contain any numbers")
  # elif not NAMES_REGEX.match(request.form['last_name']):
  #   flash("Last name cannot contain any numbers")

  # elif len(request.form['first_name'])<1:
  #   flash("You cannot leave any field blank")
  # elif len(request.form['last_name'])<1:
  #   flash("You cannot leave any field blank")
  # elif len(request.form['password'])<1:
  #   flash("You cannot leave any field blank")
  # elif len(request.form['confirm_password'])<1:
  #   flash("You cannot leave any field blank")

  return redirect('/')

app.run(debug=True)
