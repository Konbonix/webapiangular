//app-vr.js 
(function () {
    "use strict";


    //create module
    angular.module("app-vr", ["ngRoute", 'ngFileUpload'])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                templateUrl: "/angular/testview.html"
            });

            $routeProvider.when("/albums", {
                templateUrl: "/angular/albums/albumsView.html"

            });

            $routeProvider.when("/upload", {
                controller: "uploadsController",
                controllerAs: "vm",
                templateUrl: "/angular/uploads/uploadsView.html"
            });

        });

})();