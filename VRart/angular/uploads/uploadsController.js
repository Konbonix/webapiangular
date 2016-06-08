(function () {
    "use strict";

    //get the angular module
    //angular.module("app-vr")
    //    .controller("uploadsController", uploadsController);
    //function uploadsController($http) {
    //    var vm = this;
    //    vm.name = "Test";
    //}


    //inject angular file upload directives and services.
    //var app = angular.module('fileUpload', ['ngFileUpload']);

    angular.module("app-vr")
        .controller('uploadsController', ['$scope', 'Upload', '$timeout', '$location', '$rootScope', function ($scope, Upload, $timeout, $location, $rootScope) {
        $scope.$watch('files', function () {
            $scope.upload($scope.files);
        });
        $scope.$watch('file', function () {
            if ($scope.file != null) {
                $scope.files = [$scope.file];
            }
        });
        $scope.log = '';
        var vm = this;
        vm.albumid = "empty";

        $scope.upload = function (files) {
            if (files && files.length) {
               
                    var file = files[0];
                    if (!file.$error) {
                        Upload.upload({
                            url: '/api/uploads/',
                            data: {
                                file: file
                            }
                        }).then(function (resp) {
                            //Success
                            $timeout(function () {
                                $scope.log = 'file: ' +
                                resp.config.data.file.name +
                                ', Response: ' + JSON.stringify(resp.data) +
                                '\n' + $scope.log;
                                vm.albumid = JSON.stringify(resp.data);
                                $scope.albumid = resp.data;


                                alert($scope.albumid);
                                //Why does angular $window not work? or window.location?
                                window.location.replace("#/albums/" + $scope.albumid);
                            });



                        }, null, function (evt) {
                            var progressPercentage = parseInt(100.0 *
                    		        evt.loaded / evt.total);
                            $scope.log = 'progress: ' + progressPercentage +
                    	        '% ' + evt.config.data.file.name + '\n' +
                              $scope.log;
                        })
                        .finally(function () {                          
                           
                        });

                      
                    }


                
            }
        };
    }]);


})();