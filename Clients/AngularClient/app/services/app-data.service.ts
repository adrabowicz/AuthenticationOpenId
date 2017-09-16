import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { AppTokenService } from './app-token.service';

@Injectable()
export class AppDataService {
    constructor(private http: Http, private tokenService: AppTokenService) { }

    getData(): Observable<Response> {

        let token = this.tokenService.getAccessToken();
        let authorizationHeaderValue = 'Bearer ' + token;

        var headers = new Headers();
        headers.append('Authorization', authorizationHeaderValue);

        let url = "";

        return this.http.get(url, { headers: headers })
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
