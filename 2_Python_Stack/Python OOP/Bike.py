class Bike(object):
  def __init__(self, price=None, max_speed=None):
    self.price = price
    self.max_speed = max_speed
    self.miles = 0

  def displayInfo(self):
    print (self.price)
    print (self.max_speed)
    print (self.miles)
    return self

  def ride(self):
    self.miles += 10
    print ("Riding", self.miles)
    return self

  def reverse(self):
    self.miles -= 5
    print ("Reversing", self.miles)
    return self

bike1 = Bike(200, "25mph")
bike2 = Bike(150, "20mph")
bike3 = Bike(100, "15mph")


bike1.reverse().reverse().reverse().ride().displayInfo()

