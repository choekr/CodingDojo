import random 
import datetime

today = datetime.datetime.now()

print 'Current time: ', today

def bubble_sort(sampleList):
  for i in range(len(sampleList)):
    for j in range(len(sampleList)-1):
      if sampleList[j] > sampleList[j+1]:
        sampleList[j], sampleList[j+1] = sampleList[j+1], sampleList[j]
  return sampleList;

numbers = random.sample (xrange(10001), 100)

print 'Unsorted List: ', numbers

print 'Sorted List: ', bubble_sort(numbers)

print 'Current time: ', today
