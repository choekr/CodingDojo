from flask import Flask, render_template, redirect, request, session
import random 

app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

@app.route('/')
def index():
  if 'myGold' not in session: 
    session['myGold'] = 0

  if 'activityLog' not in session:
    session['activityLog'] = []
  return render_template('index.html')

@app.route('/process_money', methods=['POST'])
def process():
  building = request.form['building']

  if building == 'Farm':
    newGold = random.randint(10,20)
    session['myGold'] += newGold
  if building == 'Cave':
    newGold = random.randint(5,10)
    session['myGold'] += newGold
  if building == 'House':
    newGold = random.randint(2,5)
    session['myGold'] += newGold
  if building == 'Casino':
    newGold = random.randint(-50,50)
    session['myGold'] += newGold
  
  activity = {
    'activity': 'You {} {} {} from the {}'.format('earned' if newGold>0 else 'lost', abs(newGold), 'gold' if 0 <= newGold <= 1 else 'golds', building),
    'color': 'green' if newGold>0 else 'red',
  }
  session['activityLog'].append(activity)

  return redirect('/')

@app.route('/reset', methods=['POST'])
def reset():
  session.clear()

  return redirect('/')

app.run(debug=True)
