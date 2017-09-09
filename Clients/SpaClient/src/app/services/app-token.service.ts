import { Injectable } from '@angular/core';

@Injectable()
export class AppTokenService {

    token: ""

    constructor() { }

    getToken = function () {
        if (this.token === "") {
            if (localStorage.getItem("access_token") === null) {

                var url =
                    "http://localhost:5000/identity/connect/authorize?" +
                    "client_id=angular_app&" +
                    "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
                    "response_type=token&" +
                    "scope=common_menu_api";

                // redirect to the Identity Server
                window.location.href = url;
            }
            else {
                this.setToken(localStorage["access_token"]);
            }
        }
        return this.container;
    };

    setToken = function (token) {
        this.token = token;
    };
}
