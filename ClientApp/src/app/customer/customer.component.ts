import { ConstantPool } from '@angular/compiler';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { IReservationRequest } from '../checkout/interfaces/IReservationRequest';
import { IFlight } from '../dispatcher/interfaces/iFlight';
import { IUser } from '../login/interfaces/iUser';
import { AuthenticationService } from '../services/authentication.service';
import { IFlightSearch } from './interfaces/iFlightSearch';
import { IReservation } from './interfaces/iReservation';
import { CustomerService } from './services/customer.service';

@Component({
    templateUrl: 'customer.component.html',
    styleUrls: ['./customer.component.scss']
})

export class CustomerComponent implements OnInit {

    newFlightSearch: IFlightSearch;
    foundFlights: IFlight[];
    isLoading = true;
    user: IUser;
    reservations: IReservation[];
    constructor(
        private router: Router,
        private customerService: CustomerService,
        private authenticationService: AuthenticationService
    ) {
        this.user = this.authenticationService.userValue;
        window.paypal = paypal;
        this.foundFlights = [] as IFlight[];
        this.reservations = [] as IReservation[];
        this.newFlightSearch = {} as IFlightSearch;
    }
    ngOnInit(): void {
        this.customerService.getUserReservations(this.user.id).subscribe(reservations => {
            this.reservations = reservations;
        },
        error => {
            console.log(error);
        });
    }

    onClickFindFlights() {
        console.log(this.newFlightSearch.departureDate);
        this.customerService.searchFlights(this.newFlightSearch).subscribe(flights => {
                this.foundFlights = flights;
                this.isLoading = false;
            },
            error => {
                console.log(error);
            });

    }

    onClickCheckout(flightId: number) {
        this.router.navigate(['/checkout', { id: flightId}]);
    }

}

