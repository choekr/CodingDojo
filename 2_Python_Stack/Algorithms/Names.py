#Part 1
students = [ 
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]

def fullName (students):
  for name in students:
    print name['first_name'], name['last_name']

fullName(students)

#Part 2
users = {
 'Students': [ 
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }

def names(users):
  for key, data in users.items():
    print key
    for ind, name in enumerate(data):
      name_count = len(name["first_name"]) + len(name["last_name"])
      full_name = name["first_name"] + " " + name["last_name"]
      full_name_upper = full_name.upper()
      print ind+1, "-", full_name_upper, "-", name_count
      
names(users)
