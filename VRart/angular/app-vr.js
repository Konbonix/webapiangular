//app-vr.js 
(function () {
    "use strict";


    //create module
    angular.module("app-vr", ["ngRoute", 'ngFileUpload'])
        .config(function ($routeProvider, $locationProvider) {


            $routeProvider.when("/", {
                controller: "albumsController",
                controllerAs: "vm",
                templateUrl: "/angular/albums/albumsView.html"

            });

            $routeProvider.when("/upload", {
                controller: "uploadsController",
                controllerAs: "vm",
                templateUrl: "/angular/uploads/uploadsView.html"
            });

            $routeProvider.when("/abc", {
                controller: "albumsController",
                controllerAs: "vm",
                templateUrl: "/angular/albums/albumsView.html"
            });

        });

})();