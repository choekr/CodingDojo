//Setting and swapping

function setSwap(num, name) {
  var myNumber = num;
  var myName = name;
  var temp = myNumber;
  myNumber = myName;
  myName = temp;
  console.log ("My number is " + myNumber);
  console.log ("My name is " + myName);
}

setSwap(42, 'Kukrim Choe');

//Print and Count

function printCount() {
  var count = 0;
  for (var i=512; i<=4096; i++) {
    if(i%5 === 0) {
      console.log(i);
      count += 1;
    }
  }
  console.log(count);
}

printCount();

//Print -52 to 1066

function printOne() {
  for (var i= -52; i<=1066; i++) {
    console.log(i);
  }
}

printOne();

//Multiples of Six

function mulSix() {
  var i = 0;
  while (i<=60000) {
    i+=1;
    if (i%6 === 0) {
      console.log(i);
    }
  }
}

mulSix();

//Don't Worry, Be Happy

function beCheerful() {
  for (var i=1; i<=98; i++) {
    console.log("good morning");
  }
}
