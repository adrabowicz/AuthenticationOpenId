(function () {
    "use strict";

    angular.module("common.services",
                    ["ngResource"])
      	.constant("appSettings",
        {
            tripGalleryAPI: "http://localhost:42040/" 
        });

     
 
}());
