var mongoose = require('mongoose');

var AnimalSchema = new mongoose.Schema({
  name: String,
  type: String
})

var Animal = mongoose.model('Animal', AnimalSchema);
