#Part 1

def draw_stars(list):
  for val in list: 
    print int(val)*"*"

x = [4, 6, 1, 3, 5, 7, 25]
draw_stars(x)

#Part 2

def draw_stars2(list):
  for val in list: 
    try: 
      print int(val)*"*"
    except ValueError:
      print val[0].lower() * len(val)

x = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
draw_stars2(x)
