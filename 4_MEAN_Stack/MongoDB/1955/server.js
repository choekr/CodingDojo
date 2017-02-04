var express = require('express'),
app = express(), 
path = require('path'),
bp = require('body-parser'),
port = 8000;

app.use(bp.urlencoded());
app.use(express.static(path.join(__dirname+'/static')));
app.use(bp.json());

app.set('views', path.join(__dirname+'/client/views'));
app.set('view engine', 'ejs');

require('./server/config/mongoose');
require('./server/config/routes')(app);

app.listen(port, function(){
  console.log('Now listening on port '+port)
})
