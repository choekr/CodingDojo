def multiply (listIn, val):
  newList=[]
  for element in listIn:
    newList += [element * val]
  print newList

a=[2,4,10,16]
b = multiply(a, 5)
print b
