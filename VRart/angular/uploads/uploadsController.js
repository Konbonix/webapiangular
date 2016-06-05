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
        .controller('uploadsController', ['$scope', 'Upload', '$timeout', function ($scope, Upload, $timeout) {
        $scope.$watch('files', function () {
            $scope.upload($scope.files);
        });
        $scope.$watch('file', function () {
            if ($scope.file != null) {
                $scope.files = [$scope.file];
            }
        });
        $scope.log = '';

        $scope.upload = function (files) {
            if (files && files.length) {
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (!file.$error) {
                        Upload.upload({
                            url: '/api/uploads/',
                            data: {
                                file: file
                            }
                        }).then(function (resp) {
                            $timeout(function () {
                                $scope.log = 'file: ' +
                                resp.config.data.file.name +
                                ', Response: ' + JSON.stringify(resp.data) +
                                '\n' + $scope.log;
                            });
                        }, null, function (evt) {
                            var progressPercentage = parseInt(100.0 *
                    		        evt.loaded / evt.total);
                            $scope.log = 'progress: ' + progressPercentage +
                    	        '% ' + evt.config.data.file.name + '\n' +
                              $scope.log;
                        });
                    }
                }
            }
        };
    }]);


})();