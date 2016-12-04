from flask import Flask, flash, render_template, redirect, request, session
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/process', methods=['Post'])
def process():
  if len(request.form['email']) <1:
    flash("Email cannot be blank!")
  elif not EMAIL_REGEX.match(request.form['email']):
    flash("Invalid Email Address!")
  else: 
    flash("Success!")
  return redirect('/')

app.run(debug=True)
