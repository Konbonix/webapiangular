//home-controller
(function () {
    "use strict";

    //get the angular module
    angular.module("app-vr")
        .controller("albumsController", albumsController);

    function albumsController($http) {
        var vm = this;
        vm.name = "Test";
    }

})();