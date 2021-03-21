import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IUser } from '../login/interfaces/iUser';

@Injectable ({ providedIn: 'root'})
export class UserService {
    constructor(private http: HttpClient) {
    }

    getAll() {
        return this.http.get<IUser[]>(`${environment.apiUrl}Users/GetUsers`);
    }

    getById(id: number) {
        return this.http.get<IUser>(`${environment.apiUrl}Users/GetUsers/${id}`);
    }

    editUser(user: IUser) {
        return this.http.post<IUser>(`${environment.apiUrl}Users/EditUser`, user);
    }
}
