var express = require('express');
var app = express();

var bp = require('body-parser');
var path = require('path');
var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/quoting_dojo_redux')

var QuoteSchema = new mongoose.Schema({
  Name: String,
  Quote: String
}, {timestamps: true})

mongoose.model('quotes', QuoteSchema);
var Quote = mongoose.model('quotes');

app.use(bp.urlencoded());
app.use(express.static(path.join(__dirname + '/static')));

app.set('views', path.join(__dirname+'/views'));
app.set('view engine', 'ejs');

app.get('/', function(req, res){
  Quote.find({}, function(err) {
    if(err){
      console.log('something is wrong');
    } else {
      console.log('successfully displaying index.ejs')
      res.render('index');
    }
  })
})

app.get('/quotes', function(req, res){
  Quote.find({}, function(err, quotes){
    if(err){
      console.log(err);
    } else {
      res.render('quotes', {data: quotes})
    }
  })
})

app.post('/quotes', function(req, res){
  console.log("POST DATA", req.body);
  Quote.create(req.body, function(err, quotes){
    if(err){
      console.log(err);
    } else {
      console.log('SUCCESS');
      res.redirect('/quotes');
    }
  })
})

app.listen(8000, function(){
  console.log('Currently listening on port 8000');
})
