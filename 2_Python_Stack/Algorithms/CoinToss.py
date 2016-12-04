import random

def coinToss():
  headCount = 0
  tailCount = 0
  for toss in range(1,5001):
    random_num = random.random()
    if round(random_num) == 0:
      side = "head!"
      headCount+=1
    elif round(random_num) == 1:
      side = "tail!"
      tailCount+=1
    print "Attempt #", toss, ": Throwing a coin... It's a", side, "...Got", headCount, "head(s) so far and", tailCount, "tail(s) so far"
  print "Ending the program, thank you!"
coinToss()
