var mongoose = require('mongoose');
var Model1955 = mongoose.model('1955');

module.exports = {
  show: function(req, res){
    Model1955.find({}, function(err, names){
      if(err){
        console.log(err);
      } else {
        res.json(names);
      }
    })
  },
  add: function(req,res){
    Model1955.create({name: req.params.name}, function(err, name){
      if(err){
        console.log(err);
      } else {
        // res.json(name);
        res.redirect('/');
      }
    })
  },
  remove: function(req,res){
    Model1955.remove({name:req.params.name},
      function(err,name){
        if(err){
          console.log(err);
        } else {
          // res.json(name);
          res.redirect('/');
        }
      })
  },
  find: function(req,res){
    Model1955.find({name:req.params.name}, function(err,name){
        if(err){
          console.log(err);
        } else {
          res.json(name);
        }
      })
  }
}
