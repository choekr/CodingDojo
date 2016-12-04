from flask import Flask, render_template, request, redirect
app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def index():
  return render_template("index.html")

@app.route('/result', methods=['GET', 'POST'])
def user_info():
  name1 = request.form['name0']
  location1 = request.form['location0']
  language1 = request.form['language0']
  comment1 = request.form['comment0']
  return render_template("user_info.html",name2=name1, location2=location1, language2=language1, comment2=comment1)

app.run(debug=True)
