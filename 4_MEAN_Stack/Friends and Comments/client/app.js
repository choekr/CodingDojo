var app = angular.module('app', ['ngRoute']);

app.config(function($routeProvider){
  $routeProvider
  .when('/',{
    templateUrl: 'partials/logreg.html'
  })
  .when('/dash', {
    templateUrl: 'partials/dash.html'
  })
  .when('/users/show_friend/:id', {
    templateUrl: 'partials/show.html'
  })
  .otherwise({
    redirectTo: '/'
  })
})
