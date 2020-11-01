import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../interfaces/iUser';

@Injectable()
export class LoginService {
    private url: string;
    constructor (private http: HttpClient) {
        this.url = 'https://localhost:5001/Users/';
    }

    login (credentials: ICredentials): Observable<IUser> {
        return this.http.post<IUser>(`${this.url}authenticate`, credentials);
    }
}
