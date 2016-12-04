# class Animal(object):
#   def __init__(self, color):
#     self.color=color

# my_animal = Animal("green") #Create an object called my_animal, with color='green'.

class ListNode(object):
  def __init__(self, value):
    self.value = value
    self.next = None

class SLList(object):
  def __init__(self):
    self.head = None
  def add_to_front(self, value):
    new_node = ListNode(value)
    new_node.next = self.head
    self.head = new_node
    return self

# my_list = SLList()
# # my_list.add_to_front(4).add_to_front(7).add_to_front(2)

# print(my_list.head.value)

  # def __repr__(self): # for python 2 & 3
  def __str__(self): # for python 3
    nodes = []
    runner = self.head
    while runner: 
      nodes.append(str(runner.value))
      runner = runner.next
    return " => ".join(nodes)

my_list = SLList()

my_list.add_to_front(4).add_to_front(2).add_to_front(1).add_to_front(7).add_to_front(5)

print (my_list)
