app.factory('userFactory', function($http, $location, $route){
  var factory = {};

  factory.login = function(user){
    $http.post('/login', user).then(function(output){
      if(output.data){
        $location.url('/dash')
      }
    })
  }

  factory.checkStatus = function(cb){
    $http.get('/checkStatus').then(function(output){
      if(!output.data && $location.$$path !== '/logreg'){
        $location.url('/');
      } else {
        cb(output.data);
      }
    })
  }

  factory.getUsers = function(cb){
    $http.get('/users/others').then(function(output){
      cb(output);
      // $location.url('/dash')  
      // $route.reload();

    })
  }

  factory.getFriends = function(cb){
    $http.get('/users/friends').then(function(output){
      cb(output);
      $location.url('/dash');
    })
  }

  factory.addFriend = function(newFriend){
    $http.post('/users/add_friend', newFriend).then(function(output){
      $route.reload();
    })
  }

  factory.showFriend = function(id){
    $location.url('/users/show_friend/' + id)
  }

  factory.getAll = function(cb){
    $http.get('/users/all').then(function(output){
      cb(output);
    })
  }

  return factory;
})
