import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IFlight } from 'src/app/dispatcher/interfaces/iFlight';
import { environment } from 'src/environments/environment';
import { IFlightSearch } from '../interfaces/iFlightSearch';

@Injectable()
export class CustomerService {
    constructor(private http: HttpClient) {
    }

    searchFlights(searchParameters: IFlightSearch) {
        return this.http.post<IFlight[]>(`${environment.apiUrl}Flights/SearchFlights`, searchParameters);
    }
}
