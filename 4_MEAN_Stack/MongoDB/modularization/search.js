var dictionary = require('./dictionary.js');

function search(word, dictionary) {
  for (w in dicitonary){
    if (dictionary[w] == word) {
      return true;
    }
  }
  return false;
}

