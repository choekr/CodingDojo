app.controller('commentController', function($scope, commentsFactory, $location, $rootScope, $routeParams){
  $scope.err=[];
  
  // commentsFactory.getComments(function(data){
  //   $scope.comments = data.data;
  // })

  $scope.addComment = function(id){
    $scope.err = [];
    if(!$scope.comment) {
      $scope.err.push('Please enter something!')
    } else {
      $scope.comment._owner = id;
      commentsFactory.addComment($scope.comment);
      $scope.comment = {};
    }
  }
})
