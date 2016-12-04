class Car(object):
  def __init__(self, price, speed, fuel, mileage):
    self.price = price
    self.speed = speed
    self.fuel = fuel
    self.mileage = mileage
    if self.fuel == "Full":
      self.fuel = "Full"
    elif self.fuel == "Not Full":
      self.fuel = "Not Full"
    elif self.fuel == "Kind of Full":
      self.fuel = "Kind of Full"
    elif self.fuel == "Empty":
      self.fuel = "Empty"
    else: 
      self.fuel = "You can only choose to say: 'Full', 'Kind of Full', and 'Not Full'."
    if self.price > 10000:
      self.tax = 0.15
    else: 
      self.tax = 0.12
    self.display_all()
    
  def display_all(self):
    print("Price: ", self.price)
    print("Speed: ", self.speed, "mph")
    print("Fuel: ", self.fuel)
    print("Mileage: ", self.mileage, "mpg")
    print("Tax: ", self.tax)
    return self

mycar1 = Car(1,2,'Full',4)
mycar2 = Car(4,3,2,1)
mycar3 = Car(5,6,7,8)
mycar4 = Car(8,7,6,5)
mycar5 = Car(2,3,4,5)
mycar6 = Car(5,4,3,2)


