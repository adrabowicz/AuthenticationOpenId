(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("tokenContainer",
                  [tokenContainer])

    function tokenContainer() {
   
        var container = {
            token: ""
        };
         
        var setToken = function (token) {
            container.token = token;
        };

        var getToken = function () {
            if (container.token === "") {
                if (localStorage.getItem("access_token") === null) {

                    var url =
                        "http://localhost:5000/identity/connect/authorize?" +
                        "client_id=angular_app&" +
                        "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
                        "response_type=token&" +
                        "scope=common_menu_api";

                    // redirect to the Identity Server
                    window.location = url;
                }
                else {
                    setToken(localStorage["access_token"]);
                }
            }
            return container;
        };

        // return value to call when calling the API 
        return {
            getToken: getToken
        };
    };
})();