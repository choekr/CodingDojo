for val in range(1, 2001): 
  if val%2 != 0: 
    print "Number is", str(val) + ". This is an odd number."
  else: 
    print "Number is", str(val) + ". This is an even number."

# or 

# for val in range(1, 2001): 
#   if val%2 != 0: 
#     print "Number is {}. This is an odd number.".format(val)
#   else: 
#     print "Number is {}. This is an even number.".format(val)
