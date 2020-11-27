import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from 'src/app/login/interfaces/iUser';
import { environment } from 'src/environments/environment';

@Injectable()
export class AdministratorService {

    constructor(private http: HttpClient) {
    }

    getAll() {
        return this.http.get<IUser[]>(`${environment.apiUrl}Users/GetUsers`);
    }

    createUser(user: IUser) {
        return this.http.post<IUser>(`${environment.apiUrl}Users/CreateUser`, user);
    }

    editUser(user: IUser) {
        return this.http.post<IUser>(`${environment.apiUrl}Users/EditUser`, user);
    }

    deleteUser(id: number) {
        return this.http.delete<number>(`${environment.apiUrl}Users/DeleteUser/${id}`);
    }

}
