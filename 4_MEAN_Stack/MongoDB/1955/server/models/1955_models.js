var mongoose = require('mongoose');

var ApiSchema = new mongoose.Schema({
  name: {type: String, required: true}
})

var Api = mongoose.model('1955',ApiSchema);
