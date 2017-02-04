app.factory('commentsFactory', function($http, $location, $route){
  var factory = {};

  factory.addComment = function(comment){
    $http.post('/comment/add_comment', comment).then(function(output){
      $route.reload();
      // console.log(output);
    })
  }

  // factory.getComments = function(cb){
  //   $http.post('/comment/get_comments').then(function(output){
  //     cb(output);
  //   })
  // }

  return factory;
})
