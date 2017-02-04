var message = require('./../controllers/messages.js');
var comment = require('./../controllers/comments.js');

module.exports = function(app){
  app.get('/', function(req,res){
    message.index(req, res);
  }),
  app.post('/new_message', function(req,res){
    message.create(req, res);
  })
  app.post('/new_comment/:id', function(req,res){
    comment.create(req, res);
  })
}
