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
var http_1 = require("@angular/http");
var LoginComponent = (function () {
    function LoginComponent(http) {
        this.http = http;
        this.loginError = "";
        this.credentials = {
            username: "",
            password: ""
        };
    }
    LoginComponent.prototype.submit = function () {
        this.loginError = "";
        // get the token, using the resource owner password
        // credentials flow 
        // the message body
        var dataForBody = "grant_type=password&" +
            "username=" + encodeURI(this.credentials.username) + "&" +
            "password=" + encodeURI(this.credentials.password) + "&" +
            "scope=" + encodeURI("gallerymanagement");
        // RFC requirements: when clientid/secret are provided,
        // they must be sent through the Authorization header.
        // cfr:https://tools.ietf.org/html/rfc6749#section-4.3
        // encode the client id & client secret (btoa = built-in function
        // for Base64 encoding)
        var encodedClientIdAndSecret = btoa("tripgalleryropc:myrandomclientsecret");
        // the header
        var messageHeaders = {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': 'Basic ' + encodedClientIdAndSecret
        };
        //return null;
        //return this.http({
        //    method: 'POST',
        //    url: "https://localhost:44317/identity/connect/token",
        //    headers: messageHeaders,
        //    data: dataForBody
        //}).success(function (data) {
        //    // set the access token
        //    localStorage["access_token"] = data.access_token;
        //    // clear un/pw
        //    this.credentials.username = "";
        //    this.credentials.password = "";
        //    // redirect to root
        //    window.location.href = window.location.protocol + "//" + window.location.host + "/";
        //}).error(function (data) {
        //    // show error on screen
        //    this.loginError = data.error;
        //    // clear un/pw
        //    this.credentials.username = "";
        //    this.credentials.password = "";
        //});
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        templateUrl: './login.component.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map