from flask import Flask, render_template, request, redirect, flash
app = Flask(__name__)
app.secret_key = "KeepItSafeKeepItSecret"

@app.route('/')
def index():
  return render_template("index.html")

@app.route('/result', methods=['POST'])
def user_info():
  if len(request.form['name0'])<1:
    flash("Name field cannot be blank!")
    # return redirect('/')
    return render_template("index.html")

  elif len(request.form['comment0'])<1:
    flash("Comment field cannot be blank!")
    # return redirect('/')
    return render_template("index.html")

  elif len(request.form['comment0'])>120:
    flash("Comment cannot exceed 120 characters")
    return render_template("index.html")
    
  else:
    name1 = request.form['name0']
    location1 = request.form['location0']
    language1 = request.form['language0']
    comment1 = request.form['comment0']
    return render_template("user_info.html",name2=name1, location2=location1, language2=language1, comment2=comment1)

app.run(debug=True)
