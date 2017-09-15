import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent {
    loginError = "";
    credentials = {
        username: "",
        password: ""
    };

    constructor(private http: Http) {
    }

    submit() {
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
    }
}
