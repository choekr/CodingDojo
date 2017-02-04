var mongoose = require('mongoose');
var Message = mongoose.model('Message');
var Comments = mongoose.model('Comment');
var errorMessages = [];

module.exports = (function() {
  return{
    index: function(req, res){
      Message.find({}, function(err, messages){
        if (errorMessages != []){
          err = errorMessages;
        }
        Comments.find({}, function(err, comments){

          res.render('index', {data: messages, c_data: comments, title:"You have errors", errors: err});
          errorMessages =[];
        })
      })
    },
    create: function(req,res){
      Message.findOne(req.body, function(err,data){
        if(!data){
          // var message = new Message(data);
          Message.create(req.body, function(err, data){
            if(err){
              if (err.errors.message){
                errorMessages.push('Message field is required!');
              }
              if (err.errors.name){
                errorMessages.push('Name field is required!');
              }
              // ******These two lines are same as Message.create(req.body, ...)... line ******
              // var message = new Message(req.body);
              // message.save(function(err){
              //   if(err){

              // Message.find({}, function(err1, messages){
                // res.render('index', {data: messages, title: 'got errors', errors: err});

                console.log(errorMessages);
              res.redirect('/')
              // })
            } else {
              res.redirect('/');
            }
          })

        } else {
          console.log('SUCCESS');
          res.redirect('/');
        }
      })
    }
    ,
    remove: function(req,res){
      Message.remove({name: req.params.name}, function(err,data){
        res.redirect('/');
      })
    }
  }
})();
