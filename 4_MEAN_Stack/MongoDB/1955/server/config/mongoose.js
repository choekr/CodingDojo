var mongoose = require('mongoose');
var fs = require('fs');
var path = require('path');
var model_path = path.join(__dirname+'./../models');

mongoose.connect('mongodb://localhost/1955')

fs.readdirSync(model_path).forEach(function(file){
  if(file.indexOf('.js')>=0){
    require(model_path + '/' + file);
  }
});
