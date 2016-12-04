from flask import Flask, flash, render_template, redirect, request, session
import random
import re
from mysqlconnection import MySQLConnector

app = Flask(__name__)
mysql = MySQLConnector(app,'Full_Friends')

app.secret_key = 'KeepItSecretKeepItSafe'

@app.route('/')
def index():
  query = "SELECT * FROM friends"
  friends = mysql.query_db(query)
  # print friends
  return render_template('index.html', all_friends=friends)

@app.route('/friends', methods=['Post'])
def create():
  query = "INSERT INTO friends (first_name, last_name, created_at, updated_at) VALUES (:first_name, :last_name, NOW(), NOW())"
  data = { 'first_name': request.form['first_name'],
           'last_name': request.form['last_name']}
  mysql.query_db(query, data)
  return redirect('/')

@app.route('/friends/<id>', methods=['POST'])
def update(id):
  query = "UPDATE friends SET first_name = :first_name, last_name = :last_name updated_at= NOW() WHERE id=:id"
  data = {
          'first_name': request.form['first_name'],
          'last_name': request.form['last_name'],
          'id': id
        }
  mysql.query_db(query,data)
  return redirect('/')

@app.route('/friends/<id>/edit', methods=['GET'])
def edit(id):
  query = "SELECT id FROM friends WHERE id= :id"
  data = {'id': id}
  edit_friend = mysql.query_db(query,data)[0]
  return render_template('edit.html', friend = edit_friend)


@app.route('/friends/<id>/delete', methods=['POST'])
def destroy(id):
  query="DELETE FROM friends WHERE id=:id"
  data={'id': id}
  mysql.query_db(query,data)
  return redirect('/')

app.run(debug=True)
