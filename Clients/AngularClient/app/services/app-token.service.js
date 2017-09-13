"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AppTokenService = (function () {
    function AppTokenService() {
        this.getToken = function () {
            if (this.token) {
                return this.token;
            }
            var tokenInLocalStorage = window.localStorage.getItem("access_token");
            if (tokenInLocalStorage) {
                this.setToken(tokenInLocalStorage);
                return tokenInLocalStorage;
            }
            var url = "http://localhost:5000/identity/connect/authorize?" +
                "client_id=angular_app&" +
                "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
                "response_type=token&" +
                "scope=common_menu_api";
            window.location.href = url; // redirect to the Identity Server
        };
        this.setToken = function (token) {
            this.token = token;
        };
    }
    return AppTokenService;
}());
AppTokenService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [])
], AppTokenService);
exports.AppTokenService = AppTokenService;
//# sourceMappingURL=app-token.service.js.map