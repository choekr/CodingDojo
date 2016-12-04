from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)

app.secret_key = 'ThisIsSecret'

def counter():
  try:
    session['counter'] += 1
  except Exception:
    session['counter'] = 1

def addTwo():
  try:
    session['counter'] += 1
  except Exception: 
    pass

def reset():
  # session.clear()
  try:
    session['counter'] = 0
  except Exception:
    pass

# @app.route('/', methods=['GET', 'POST'])
# def buttonCount():
#   #if add 2 button pressed, run counter() again
#   if request.form['addTwo'] == ['addTwo']:
#     addTwo()
#   #if reset button pressed, set session['counter']=0
#   elif request.form['reset'] == ['reset']:
#     reset()
#   else:
#     counter()

#   return render_template('index.html')


@app.route('/', methods=['GET', 'POST'])
def countFront():
  counter()
  return render_template('index.html')
  #if add 2 button pressed, run counter() again
@app.route('/addTwo', methods=['GET', 'POST'])
def addingTwo():
  addTwo()
  return redirect('/')

  #if reset button pressed, set session['counter']=0
@app.route('/reset', methods=['GET', 'POST'])
def resettingPage():
  reset()
  return redirect('/')


app.run(debug=True)
