from flask import Flask, flash, render_template, request, redirect, session
import random

app = Flask (__name__)
app.secret_key = 'ThisIsSecret'

def StartGame():
  try: 
    session.pop('output')
  except KeyError:
    pass

  session['num'] = random.randint(1,101)
  session['counter'] = 0

def reset():
  # session.pop('num')
  # session.pop('output')
  session.clear()

@app.route('/')
def start():
  if 'counter' not in session: 
    session['counter']=1
  if 'num' not in session: 
    StartGame()
  else: 
    pass
  return render_template('index.html')

@app.route('/input', methods=['POST'])
def input():
  try: 
    if session['num'] == int(request.form['guess']):
      session['counter']+=1
      session['output'] = 'Got it right!'
      return render_template('index.html')
    elif session['num'] > int(request.form['guess']):
      session['counter']+=1
      session['output'] = 'Too low!'
      return render_template('index.html')
    elif session['num'] < int(request.form['guess']):
      session['counter']+=1
      session['output'] = 'Too high!'
  except Exception:
    pass
      
  return render_template('index.html')

@app.route('/reset', methods=['POST'])
def resettingPage():
  reset()
  return redirect('/')

'''

guess = int(input())

if guess == num: 
  print('Got it right!')

elif guess < number:
  print('Too Low!')

elif guess > number: 
  print('Too High!')

'''
app.run(debug=True)
