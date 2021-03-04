import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IFlight } from 'src/app/dispatcher/interfaces/iFlight';
import { environment } from 'src/environments/environment';

@Injectable()
export class PilotService {
    constructor(private http: HttpClient) {
    }

    getAllFlights(id: number) {
        return this.http.get<IFlight[]>(`${environment.apiUrl}Flights/GetPilotFlights/${id}`);
    }

    editFlight(flight: IFlight) {
        return this.http.post<IFlight>(`${environment.apiUrl}Flights/EditFlightStatus`, flight);
    }
}
