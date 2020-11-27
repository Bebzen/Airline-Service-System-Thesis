import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUser } from '../login/interfaces/iUser';

@Injectable ({ providedIn: 'root'})
export class AuthenticationService {
    private userSubject: BehaviorSubject<IUser>;
    public user: Observable<IUser>;

    constructor (private router: Router, private http: HttpClient) {
        this.userSubject = new BehaviorSubject<IUser>(JSON.parse(localStorage.getItem('user')));
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): IUser {
        return this.userSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<IUser>(`${environment.apiUrl}Users/authenticate`, {username, password})
        .pipe(map(user => {
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
            return user;
        }));
    }

    logout() {
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/login']);
    }
}
