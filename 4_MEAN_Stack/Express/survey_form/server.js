var express = require('express');
var path = require('path');
var bp = require('body-parser');

var app = express();

app.use(bp.urlencoded({extended:true}));
// app.use(bp.urlencoded()); can be used

app.use(express.static(path.join(__dirname + '/static')));
app.set('views', path.join(__dirname + '/views'));
app.set('view engine', 'ejs');

app.get('/', function(req, res){
  res.render('index');
})

app.post('/result', function(req, res){
  res.render('user_info', {data: req.body}); //stores req.body (object) into variable called data, render it on /result page.
  
  console.log(req.body); //logs object of data passed in from index.ejs
})

app.listen(8000, function(){
  console.log('Now listening on port 8000');
})
