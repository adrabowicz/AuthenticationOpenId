import { Injectable } from '@angular/core';

@Injectable()
export class AppTokenService {

    accessToken: ""

    getAccessToken = function () {
        if (this.accessToken) {
            return this.accessToken;
        }

        let tokenInLocalStorage = window.localStorage.getItem("access_token");
        if (tokenInLocalStorage) {
            this.setAccessToken(tokenInLocalStorage);
            return this.accessToken;
        }

        var url =
            "http://localhost:5000/identity/connect/authorize?" +
            "client_id=angular_app&" +
            "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
            "response_type=token&" +
            "scope=common_menu_api";

        window.location.href = url; // redirect to the Identity Server
    };

    private setAccessToken = function (token: string) {
        this.accessToken = token;
    };
}
