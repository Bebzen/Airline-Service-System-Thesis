import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from 'src/app/login/interfaces/iUser';
import { environment } from 'src/environments/environment';
import { ICrew } from '../interfaces/iCrew';

@Injectable()
export class DispatcherService {
    constructor(private http: HttpClient) {
    }

    getAllPilots() {
        return this.http.get<IUser[]>(`${environment.apiUrl}Crews/GetAllPilots`);
    }

    createCrew(crew: ICrew) {
        return this.http.post<ICrew>(`${environment.apiUrl}Crews/CreateCrew`, crew);
    }

    getAllCrews() {
        return this.http.get<ICrew[]>(`${environment.apiUrl}Crews/GetAllCrews`);
    }

    editCrew(crew: ICrew) {
        return this.http.post<ICrew>(`${environment.apiUrl}Crews/EditCrew`, crew);
    }

    deleteCrew(id: number) {
        return this.http.delete<number>(`${environment.apiUrl}Crews/DeleteCrew/${id}`);
    }
}
