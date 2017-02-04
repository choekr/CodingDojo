var express = require('express');
var app = express();
var path = require('path');
var bp = require('body-parser');
var mongoose = require('mongoose');

app.use(bp.urlencoded());
app.use(express.static(path.join(__dirname + '/client/static')));

app.set('views', path.join(__dirname + "/client/views"));
app.set('view engine', 'ejs');

require('./server/config/mongoose.js');
require('./server/config/routes')(app);

app.listen (8000, function(){
  console.log("Running on port 8000");
})
