var mongoose = require('mongoose');
var User = mongoose.model('User');
var Comment = mongoose.model('Comment');

module.exports = (function(){
  return{
    login: function(req,res){
      User.findOne({name: req.body.name}).populate({path:'_bucketList'}).exec(function(err,data){
        if(!data){
          var user = new User(req.body);
          user.save(function(err,data){
            req.session.user = data;
            req.session.save();
            res.json(data);
          })
        } else {
          req.session.user = data;
          req.session.save();
          res.json(data);
        }
      })
    },
    checkStatus: function(req,res){
      if(req.session.user){
        User.findOne({name:req.session.user.name}).populate({path:'_bucketList'}).exec(function(err,data){
          if (err){
            res.json(err);
          } else {
            res.json(data);
          }
        });
      } else {
        res.json(null);
      }
    },
    logout: function(req,res){
      req.session.destroy();
      res.redirect('/');
    },
    getUsers: function(req,res){
      var omit = req.session.user._friends;
      omit.push(req.session.user._id);
      User.find({_id:{$nin:omit}}, function(err,data){
        if(err){
          res.json(err);
        } else {
          res.json(data);
        }
      })
    },
    addFriend: function(req,res){
      User.findOne({_id:req.session.user._id}, function(err,data){
        if(err){
          res.json(err);
        } else {
          data._friends.push(req.body.newFriend);
          data.save();
          req.session.user = data;
          res.json(data);
        }
      })
    },
    getFriends: function(req,res){
      if (req.session.user) {
        User.findOne({_id:req.session.user._id})
        .populate({path:'_friends'})
        .exec(function(err,data){
          if(err){
            console.log(err);
          } else {
            var friendsArray = data._friends;
            res.json(friendsArray);
          }
        })        
      }
    },

    getAll: function(req,res){
      User.find({}).populate({path:'_friends'}).populate({
        path:'_comments_rec', 
        populate: {path:'_creator'}
      }).exec(function(err,data){
        if(err){
          res.json(err);
        } else {
          res.json(data);
        }
      })
    }
  }
})();
