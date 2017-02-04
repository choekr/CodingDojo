var mongoose = require('mongoose');
var Comment = mongoose.model('Comment');
var User = mongoose.model('User');
module.exports = (function(){
  return{
    addComment: function(req,res) {
      console.log(req.body);
      var comment = new Comment(req.body);
      comment.comment = req.body.newComment;
      comment._creator.push(req.session.user._id);
      console.log(comment);
      comment.save(function(err){
        if(err){
          console.log(err);
        } else {
          console.log('successfully added comment');
        }
      });

      User.findOne({_id: req.session.user._id}, function(err, data){
        if(err){
          console.log(err);
        } else {
          data._comments_pos.push(comment._id);
          data.save();
        }
      })
      User.findOne({_id: req.body._owner}, function(err, data){
        if(err){
          console.log(err);
        } else {
          data._comments_rec.push(comment._id);
          data.save();
        }
      })
      res.json(null);
    }
  }
})();
