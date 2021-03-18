import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { IFlight } from '../dispatcher/interfaces/iFlight';
import { IUser } from '../login/interfaces/iUser';
import { AuthenticationService } from '../services/authentication.service';
import { PaymentDialogComponent } from './payment-dialog/payment-dialog.component';
import { CheckoutService } from './services/checkout.service';
// tslint:disable: deprecation
@Component({
    templateUrl: 'checkout.component.html',
    styleUrls: ['./checkout.component.scss']
})

export class CheckoutComponent implements OnInit {
    private sub: any;
    flightId: number;
    selectedFlight: IFlight;
    user: IUser;
    seats: string[] = [];
    takenSeats: string[] = [];
    configuration: boolean;

    constructor(private route: ActivatedRoute,
        private checkoutService: CheckoutService,
        private authenticationService: AuthenticationService,
        public dialog: MatDialog) {
        this.selectedFlight = {} as IFlight;
        this.seats = [] as string[];
        this.takenSeats = [] as string[];
        this.configuration = false;
    }
    ngOnInit(): void {
        this.user = this.authenticationService.userValue;

        this.sub = this.route.params.subscribe(params => {
            this.flightId = +params['id'];
        });

        this.checkoutService.getFlight(this.flightId).subscribe(flight => {
                this.selectedFlight = flight;
                this.configureSeats();
                this.getBoughtSeats();
            },
            error => {
                console.log(error);
            });
    }

    configureSeats(): void {
        const rows = Math.floor(this.selectedFlight.totalSeats / 6);
        console.log(rows);
        for (let i = 0; i < rows; i++) {
            this.seats[i] = (i + 1).toString();
        }
        this.configuration = true;
    }

    onClickProceedToPaypal(seat: string): void {
        this.dialog.open(PaymentDialogComponent,
            {
                width: '50%',
                data: {seat: seat, flight: this.selectedFlight, user: this.user}
            });
    }

    getBoughtSeats() {
        this.checkoutService.getTakenSeatNumbers(this.selectedFlight.id).subscribe(seats => {
            this.takenSeats = seats;
        },
        error => {
            console.log(error);
        });
    }

    checkSeatValidity = function(seatNumber: string): boolean {
        let result = this.takenSeats.find(element => element === seatNumber);
        if (result === undefined) { return false; }
        return true;
    };
}
