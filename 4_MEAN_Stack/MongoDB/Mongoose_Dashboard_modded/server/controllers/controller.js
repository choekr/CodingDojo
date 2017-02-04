var mongoose = require('mongoose');
var Animal = mongoose.model('Animal')
module.exports = {
  show: function(req, res){ //show all
    Animal.find({}, function(err, animals){
      if(err){
        res.send('error');
      }
      res.render('index', {data: animals});
    })
  },
  find: function(req, res){ //find one
     Animal.find({name: req.params.id}, function(err, animal){
      if(err){
        res.send('error');
      } else {
        res.render('index', {data:animal})
      }
    })
  },
  create: function(req, res){ //create one
    Animal.create(req.body, function(err, animal){
      if(err){
        console.log(err);
      } else {
        res.redirect('/');
      }
    })
  },
  to_edit: function(req, res){
    Animal.find({name: req.params.id}, req.body, function(err, animal){
      if(err){
        console.log(err);
      } else {
        res.render('edit', {data:animal});
      }
    })
  },
  edit: function(req, res){
    Animal.update({name: req.params.id}, req.body, function(err, animal){
      if(err){
        console.log(err);
      } else {
        res.redirect('/');
      }
    })
  },
  delete: function(req, res){
    Animal.remove({name:req.params.id}, function(err, animal){
      if(err){
        console.log(err);
      } else {
        res.redirect('/');
      }
    })
  }
}
