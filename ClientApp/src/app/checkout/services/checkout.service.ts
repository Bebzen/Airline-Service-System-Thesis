import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IReservation } from 'src/app/customer/interfaces/iReservation';
import { IFlight } from 'src/app/dispatcher/interfaces/iFlight';
import { environment } from 'src/environments/environment';
import { IEditReservationRequest } from '../interfaces/iEditReservationRequest';
import { IReservationCreationRequest } from '../interfaces/iReservationCreationRequest';

@Injectable()
export class CheckoutService {
    constructor(private http: HttpClient) {
    }

    getFlight(id: number) {
        return this.http.get<IFlight>(`${environment.apiUrl}Flights/GetFlight/${id}`);
    }

    createReservation(reservation: IReservationCreationRequest) {
        return this.http.post(`${environment.apiUrl}Reservations/CreateReservation`, reservation);
    }

    getTakenSeatNumbers(id: number) {
        return this.http.get<string[]>(`${environment.apiUrl}Reservations/GetTakenSeats/${id}`);
    }

    getFlightReservations(id: number) {
        return this.http.get<IReservation[]>(`${environment.apiUrl}Reservations/GetFlightReservations/${id}`);
    }

    editReservation(reservation: IReservation) {
        reservation.isValid = !reservation.isValid;
        return this.http.post(`${environment.apiUrl}Reservations/EditReservation`, reservation);
    }
}
