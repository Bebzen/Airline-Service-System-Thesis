import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from 'src/app/login/interfaces/iUser';
import { environment } from 'src/environments/environment';
import { ICrew } from '../interfaces/iCrew';
import { IFlight } from '../interfaces/iFlight';

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

    createFlight(flight: IFlight) {
        return this.http.post<IFlight>(`${environment.apiUrl}Flights/CreateFlight`, flight);
    }

    getAllFlights() {
        return this.http.get<IFlight[]>(`${environment.apiUrl}Flights/GetAllFlights`);
    }

    editFlight(flight: IFlight) {
        console.log(flight);
        return this.http.post<IFlight>(`${environment.apiUrl}Flights/EditFlight`, flight);
    }

    deleteFlight(id: number) {
        return this.http.delete<number>(`${environment.apiUrl}Flights/DeleteFlight/${id}`);
    }
}
