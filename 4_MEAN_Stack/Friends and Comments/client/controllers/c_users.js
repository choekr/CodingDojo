app.controller('userController', function($scope, userFactory, $location, $rootScope, $routeParams){
  $scope.err=[];
  var user = $scope.curUser;

  if($routeParams.id){
    userFactory.checkStatus(function(data){
      if(data != null){
        $scope.curUser = data;
        $rootScope.loggedIn = true;
      }
    })

    userFactory.getAll(function(data){
      $scope.users = data.data;
      for(user in $scope.users){
        if($scope.users[user]._id == $routeParams.id){
          $scope.cur_user = $scope.users[user];
        }
      }
    })

  } else {

    userFactory.checkStatus(function(data){
      if(data != null){
        $scope.curUser = data;
        $rootScope.loggedIn = true;
        $location.url('/dash');
        userFactory.getFriends(function(data){
          $scope.friends = data.data;
        })
        userFactory.getUsers(function(data){
          $scope.users = data.data;
        })
      }
    })
    
  }

  $scope.login = function(){
    $scope.err=[];
    if(!$scope.user || !$scope.user.name){
      $scope.err.push('Please enter your name!');
      $location.url('/');
    } else if ($scope.user.name.length <= 3){
      $scope.err.push('Your name must be longer than 3 characters');
    } else {
      userFactory.login($scope.user);
      $scope.user = {};
    }
  }

  $scope.addFriend = function(){
    $scope.err=[];
    if(!$scope.user){
      $scope.err.push('Please choose a user!');
      console.log($scope.err);
      // $location.url('/dash');
    } else {
      userFactory.addFriend($scope.user);
      $scope.user = {};
    }
  }

  $scope.showFriend = function(id){
    userFactory.showFriend(id);
  }
})
