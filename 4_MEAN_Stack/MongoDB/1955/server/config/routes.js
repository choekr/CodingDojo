var controller = require('../controllers/1955_controller.js');
module.exports=function(app){
  app.get('/', function(req, res){
    controller.show(req,res);
  })
  app.get('/new/:name/', function(req,res){
    controller.add(req,res);
  })
  app.get('/remove/:name/', function(req,res){
    controller.remove(req,res);
  })
  app.get('/:name', function(req,res){
    controller.find(req,res);
  })
}
