from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
from datetime import datetime
import re

app = Flask(__name__)
mysql = MySQLConnector(app,'email_validation')

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/process', methods=['POST'])
def emails():
  if not EMAIL_REGEX.match(request.form['email']):
    flash("Invalid Email Address!")
    return redirect('/')
  
  else:
    query = "INSERT INTO emails (email, created_at, updated_at) VALUES (:email, NOW(), NOW())"
    new_email = request.form['email']
    data = {'email': new_email}
    mysql.query_db(query, data)
    query = "SELECT * FROM emails"
    emails = mysql.query_db(query)
    return render_template('success.html', all_emails=emails, new_email=new_email)


# @app.route('/emails', methods=['POST'])
# def emails():
#   query = "INSERT INTO emails ((address) VALUES(:address))"

#   data = {'email_address': request.form['email']}

#   mysql.query_db(query, data)
#   return redirect('/')

app.run(debug=True)

