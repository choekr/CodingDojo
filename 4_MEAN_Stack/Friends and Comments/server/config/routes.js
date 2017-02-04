var user = require('./../controllers/users_c.js');
var comment = require('./../controllers/comments_c.js');

module.exports = function(app){
  app.post('/login', user.login);

  app.get('/checkstatus', function(req,res){
    user.checkStatus(req,res);
  });
  app.get('/logout', function(req,res){
    user.logout(req,res);
  });

  app.get('/users/others', function(req,res){
    user.getUsers(req,res);
  });

  app.get('/users/friends', function(req,res){
    user.getFriends(req,res);
  });

  app.post('/users/add_friend', function(req,res){
    user.addFriend(req,res);
  });

  app.post('/users/show_friend', function(req,res){
    user.showFriend(req,res);
  })

  app.get('/users/all', function(req,res){
    user.getAll(req,res);
  })

  app.post('/comment/add_comment', function(req,res){
    comment.addComment(req,res);
  })

  // app.get('/comment/get_comments', function(req,res){
  //   comment.getComments(req,res);
  // })
}
