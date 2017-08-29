(function () {
    //"use strict";

    var app = angular.module("tripGallery",
                            ["ngRoute", "common.services"]);
     
     

    app.config(function ($routeProvider, $httpProvider) {
 
        $routeProvider            
            .when("/trips", {
                templateUrl: "/app/trips/tripIndex.html",
                controller: "tripIndexController as vm"
            })
            .when("/login", {
                templateUrl: "/app/login/login.html",
                controller: "loginController as vm"
            })
           .otherwise({ redirectTo: "/trips" });


        $httpProvider.interceptors.push(function (appSettings, tokenContainer) {
            return {
                'request': function (config) {
                    config.headers.Authorization = 'Bearer ' + tokenContainer.getToken().token;
                    return config;
                }
            };
        });
    });




    // file upload directive cfr http://uncorkedstudios.com/blog/multipartformdata-file-upload-with-angularjs
    app.directive('fileModel', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function(scope, element, attrs) {
                var model = $parse(attrs.fileModel);
                var modelSetter = model.assign;
            
                element.bind('change', function(){
                    scope.$apply(function(){
                        modelSetter(scope, element[0].files[0]);
                    });
                });
            }
        };
    }]);

}());