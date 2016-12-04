#Part 1

class MathDojo(object):
  def __init__(self):
    self.total = 0

  def add(self, *num):
    for value in num:
      self.total += value
    return self

  
  def subtract(self, *num):
    for value in num:
      self.total -= value
    return self

  def result(self):
    print (self.total)

md = MathDojo()

md.add(2).add(2, 5).subtract(3, 2).result()


#Part II

class MathDojo(object):
  def __init__(self):
    self.total = 0

  def add(self, *num):
    for value in num:
      if(isinstance(value, tuple) or isinstance(value, list)):
        for val in value:
          self.total += val
      else:
        self.total += value
    return self

  def subtract(self, *num):
    for value in num: 
      if (isinstance(value, tuple) or isinstance(value, list)):
        for val in value: 
          self.total -= val
      else:
        self.total -= value
    return self

  def result(self):
    print("%.2f" %self.total)

md = MathDojo()

md.add([1],3,4).add([3, 5, 7, 8], (2,4), [2, 4.3, 1.25]).subtract(2, [2,3], [1.1, 2.3]).result()


