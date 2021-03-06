"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AppTokenService = (function () {
    function AppTokenService() {
        this.clientId = "angular_app";
        this.setAccessToken = function (token) {
            this.accessToken = token;
        };
    }
    AppTokenService.prototype.getAccessToken = function () {
        if (this.accessToken) {
            return this.accessToken;
        }
        var tokenInLocalStorage = window.localStorage.getItem("access_token");
        if (tokenInLocalStorage) {
            this.setAccessToken(tokenInLocalStorage);
            return this.accessToken;
        }
        var url = this.createIdentityServerAuthorizeUrl();
        window.location.href = url;
        return null;
    };
    ;
    AppTokenService.prototype.createIdentityServerAuthorizeUrl = function () {
        var scope = "common_menu_api";
        var url = "http://localhost:5000/identity/connect/authorize?" +
            "client_id=" + this.clientId + "&" +
            "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
            "response_type=token&" +
            "scope=" + scope;
        return url;
    };
    return AppTokenService;
}());
AppTokenService = __decorate([
    core_1.Injectable()
], AppTokenService);
exports.AppTokenService = AppTokenService;
//# sourceMappingURL=app-token.service.js.map