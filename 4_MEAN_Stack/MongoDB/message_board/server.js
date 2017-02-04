var express = require ('express'),
app = express(),
bp = require('body-parser'),
path = require('path'),
port = 8000;

app.use(bp.urlencoded());
app.use(express.static(path.join(__dirname+'/static')));

app.set('views', path.join(__dirname+'/views'));
app.set('view engine', 'ejs');

require('./server/config/mongoose.js'); //This line has to be above require('./server/config/route.js')(app) line
require('./server/config/route.js')(app);

app.listen(port, function(){
  console.log('Listening to port ' + port);
})
