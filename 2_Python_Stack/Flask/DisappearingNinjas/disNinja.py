from flask import Flask, flash, render_template, redirect, request, session
import random
import re

app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/ninja', methods=['GET'])
def ninjaAll():
  ninja = True
  return render_template('ninja.html', ninja=ninja)

@app.route('/ninja/<color>', methods=['GET'])
def ninjaByColor(color):
  ninja = False
  return render_template("ninja.html", color=color, ninja=ninja)

app.run(debug=True)
