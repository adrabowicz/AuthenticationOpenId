﻿import { Injectable } from '@angular/core';

@Injectable()
export class AppTokenService {

    token: ""

    constructor() { }

    getToken = function () {
        if (this.token) {
            return this.token;
        }

        let tokenInLocalStorage = window.localStorage.getItem("access_token");
        if (tokenInLocalStorage) {
            this.setToken(tokenInLocalStorage);
            return tokenInLocalStorage;
        }

        var url =
            "http://localhost:5000/identity/connect/authorize?" +
            "client_id=angular_app&" +
            "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
            "response_type=token&" +
            "scope=common_menu_api";

        window.location.href = url; // redirect to the Identity Server
    };

    setToken = function (token) {
        this.token = token;
    };
}
