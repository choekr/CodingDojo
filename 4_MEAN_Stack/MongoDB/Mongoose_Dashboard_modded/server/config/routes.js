var controller = require('../controllers/controller.js');

module.exports = function(app) {
  app.get('/', function(req,res){
    controller.show(req,res);
  })
  app.post('/', function(req,res){
    controller.create(req,res);
  })
  app.get('/new', function(req, res){
    res.render('new');
  })
  app.get('/animals/:id', function(req,res){
    // console.log(req.params);
    controller.find(req,res);
  })
  app.get('/edit/:id', function(req,res){
    controller.to_edit(req,res);
  })
  app.post('/edit/:id', function(req,res){
    controller.edit(req,res);
  })
  app.post('/destroy/:id', function(req,res){
    controller.delete(req,res);
  })
}
