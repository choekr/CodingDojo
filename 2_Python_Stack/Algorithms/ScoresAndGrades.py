def scoresGrades():
  scoreList = []
  for answer in range (10):
    print "What is your score?"
    score = input()
    scoreList += [score]

  print "Scores and Grades"

  for score in scoreList:
    if 69 >= score >= 60:
      print "Your score is", score, "Your grade is D"
    elif 79 >= score >= 70:
      print "Your score is", score, "Your grade is C"
    elif 89 >= score >= 80:
      print "Your score is", score, "Your grade is B"
    elif 100 >= score >= 90:
      print "Your score is", score, "Your grade is A"
    else:
      print "Your score is invalid. Please enter a value between 60 and 100"
  print "End of the program. Bye!"

scoresGrades()
