import { AfterViewInit, Component, ElementRef, Inject, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IReservation } from 'src/app/customer/interfaces/iReservation';
import { IFlight } from 'src/app/dispatcher/interfaces/iFlight';
import { IUser } from 'src/app/login/interfaces/iUser';
import { IReservationCreationRequest } from '../interfaces/iReservationCreationRequest';
import { CheckoutService } from '../services/checkout.service';

@Component({
    selector: 'app-payment-dialog',
    templateUrl: './payment-dialog.component.html',
    styleUrls: ['./payment-dialog.component.scss']
})
export class PaymentDialogComponent implements AfterViewInit {

    newReservation: IReservationCreationRequest;

    @ViewChild('paypalRef', {static: true}) private paypalRef: ElementRef;

    paymentAmount: number;
    ngAfterViewInit(): void {
        this.configurePaymentAmount();
        window.paypal.Buttons(
            {
                style: {
                    layout: 'horizontal',
                    label: 'paypal'
                },
                createOrder: (data, actions) => {
                    return actions.order.create({
                        purchase_units: [
                            {
                                amount: {
                                    value: this.paymentAmount
                                }
                            }
                        ]
                    });
                },
                onApprove: (data, actions) => {
                    return actions.order.capture().then(details => {
                            alert('Transaction completed');
                            console.log(details);
                            this.createTransaction(details.id);
                        }) ;
                },
                onError: error => {
                    alert('Something went wrong! Try again');
                }
            }
        ).render(this.paypalRef.nativeElement);
    }
    constructor(
        private checkoutService: CheckoutService,
        public dialogRef: MatDialogRef<PaymentDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {seat: string, flight: IFlight, user: IUser}
    ) {
        this.paymentAmount = 60;
        this.newReservation = {} as IReservationCreationRequest;
    }

    private configurePaymentAmount() {
        const length = this.data.seat.length;
        if (length === 2) {
            switch (this.data.seat[1]) {
                case 'A' : {this.paymentAmount = 100; break; }
                case 'F' : {this.paymentAmount = 100; break; }
                default: {this.paymentAmount = 50; break; }
            }
        } else {
            switch (this.data.seat[2]) {
                case 'A' : {this.paymentAmount = 100; break; }
                case 'F' : {this.paymentAmount = 100; break; }
                default: {this.paymentAmount = 50; break; }
            }
        }
        return this.paymentAmount;
    }

    private createTransaction(transactionId: string) {
        this.newReservation.flight = this.data.flight;
        this.newReservation.price = this.paymentAmount;
        this.newReservation.seatNumber = this.data.seat;
        this.newReservation.userId = this.data.user.id;
        this.newReservation.transactionId = transactionId;
        this.newReservation.isValid = true;
        this.checkoutService.createReservation(this.newReservation).subscribe(result => {
            alert('Reservation created');
        },
        error => {
            console.log(error);
        });
    }
}


declare global {
    interface Window {
        paypal: any;
    }
}
