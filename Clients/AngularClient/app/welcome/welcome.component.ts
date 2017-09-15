import { Component } from '@angular/core';

@Component({
    templateUrl: './welcome.component.html'
})
export class WelcomeComponent {

    callApi(): void {
        alert("Call API clicked");
    }
}
