(function () {
    "use strict";

    angular.module("common.services",
                    ["ngResource"])
      	.constant("appSettings",
        {
            testApiUrl: "http://localhost:43000/" 
        });

     
 
}());
