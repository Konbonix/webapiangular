//home-controller
(function () {
    "use strict";

    //get the angular module
    angular.module("app-albums")
        .controller("albumsController", albumsController);

    function albumsController($http) {
        var vm = this;
        vm.name = "Test";
    }

})();