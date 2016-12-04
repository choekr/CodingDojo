class Animal (object):
  def __init__ (self, name):
    self.name = name
    self.health = 100

  def walk(self):
    self.health -= 1
    return self
  def run(self):
    self.health -= 5
    return self
  def displayHealth(self):
    print (self.name)
    print (self.health)


Animals = Animal("animal")

Animals.walk().walk().walk().run().run().displayHealth()


class Dog (Animal):
  def __init__ (self, name):
    super(Dog, self).__init__(name)
    self.health = 150
  def pet(self):
    self.health+=5
    return self

Dog = Dog("Dog")

Dog.walk().walk().walk().run().run().pet().displayHealth()

class Dragon1(Animal):
  def __init__ (self, name):
    super(Dragon1, self).__init__(name)
    self.health = 170
  def fly(self):
    self.health-=10
    return self
  def displayHealth(self):
    print ("'this is a dragon!'")
    super(Dragon1, self).displayHealth()

Dragon = Dragon1("Dragon")

Dragon.walk().walk().walk().run().run().fly().fly().displayHealth()
