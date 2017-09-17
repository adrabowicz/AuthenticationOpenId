import { Injectable } from '@angular/core';

@Injectable()
export class AppTokenService {

    accessToken: ""
    clientId = "angular_app";

    getAccessToken(): string {
        if (this.accessToken) {
            return this.accessToken;
        }

        let tokenInLocalStorage = window.localStorage.getItem("access_token");
        if (tokenInLocalStorage) {
            this.setAccessToken(tokenInLocalStorage);
            return this.accessToken;
        }

        var url = this.createIdentityServerAuthorizeUrl();
        window.location.href = url;
        return null;
    };

    private setAccessToken = function (token: string) {
        this.accessToken = token;
    };

    private createIdentityServerAuthorizeUrl(): string {
        let scope = "common_menu_api";
        let url = "http://localhost:5000/identity/connect/authorize?" +
                    "client_id=" + this.clientId + "&" +
                    "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
                    "response_type=token&" +
                    "scope=" + scope;
        return url;
    }
}
