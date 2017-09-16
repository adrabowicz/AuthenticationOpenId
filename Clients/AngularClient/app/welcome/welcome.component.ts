import { Component } from '@angular/core';

import { AppDataService} from '../services/app-data.service';

@Component({
    templateUrl: './welcome.component.html'
})
export class WelcomeComponent {

    constructor(private appDataService: AppDataService) {
    }

    callApi(): void {
        this.appDataService.getData();
    }
}
