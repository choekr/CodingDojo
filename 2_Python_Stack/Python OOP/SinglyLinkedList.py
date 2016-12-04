class Node(object):
  def __init__(self, value):
    self.value = value
    self.next = None

class SinglyLinkedList(object):
  def __init__(self):
    self.head = None
    self.tail = None

  def PrintAll(self, head):
    if head:
      print (head.value)
      self.PrintAll(head.next)
  
  def PrintAllVals(self):
    self.PrintAllVals(self.head)

  def AddBack(self):
      node = myList.head
      while node:
          yield node
          node = node.next

  def reverse_list(head):
      new_head = None
      while head:
          head.next, head, new_head = new_head, head.next, head
      return new_head

myList = SinglyLinkedList()
myList.head = Node('Alice')
myList.head.next = Node('Chad')
myList.head.next.next = Node('Debra')

myList.printlist()#Prints all values
# print ([node.value for node in myList])# Print all values

# list.head.next = Node('Ben')
