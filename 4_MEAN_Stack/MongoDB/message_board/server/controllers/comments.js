var mongoose = require('mongoose');
var Comment = mongoose.model('Comment');
var Message = mongoose.model('Message');
var errorComments = []; 

module.exports = (function() {
  return{
    index: function(req, res){
      if(errorComments != []){
          err = errorComments;
      }
      
      Comment.find({}, function(err, comments){
        res.render('index', {errors: err});
      })
    },
    create: function(req,res){
      Message.findOne({_id:req.params.id}, function(err,message){
        if(err){
          console.log(err);
          res.redirect('/', {errors: err});
        } else {
          var comment = new Comment(req.body);

          message._comments.push(comment._id);
          comment._message = message._id;
          
          Comment.create(comment, function(err, data){
            if(err){
              res.redirect('/', {errors:err});
            } else {
              message.save(function(err){
                if(err) {
                  console.log('Error');
                  res.redirect('/', {errors:err});
                }
              })
              res.redirect('/');
            }
          })
        }
      })
    },
    remove: function(req,res){
      Comment.remove({name: req.params}, function(err,data){
        res.redirect('/');
      })
    }
  }
})();
