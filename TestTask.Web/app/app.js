var app = angular.module('testTask', ['ngRoute']);
app.config(($routeProvider) => {

    $routeProvider.when("/", {
        controller: "bookCtrl",
        templateUrl: "/app/views/BookView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });

});
//app.constant("baseUrl", "http://localhost:16334/api/");