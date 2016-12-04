def varargs(arg1, *restOfArg):

    print (str(type(restOfArg)))
    print (str(restOfArg).join(''))

varargs(1,2,3,4)

