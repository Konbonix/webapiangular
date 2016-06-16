//home-controller
(function () {
    "use strict";

    //get the angular module
    angular.module("app-vr")
        .controller("albumsController", albumsController);

    function albumsController($http) {
        var vm = this;
        vm.albumsOverview = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        var url = "/api/albums/"; 

        //Load all albums from API
        $http.get(url)
          .then(function (response) {
              // success
              angular.copy(response.data, vm.albumsOverview);
          }, function (err) {
              // failure
              vm.errorMessage = "Failed to load sights";
          })
          .finally(function () {
              vm.isBusy = false;
          });




    } 

})();