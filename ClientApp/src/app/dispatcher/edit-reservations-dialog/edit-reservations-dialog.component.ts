import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { CheckoutService } from "src/app/checkout/services/checkout.service";
import { IReservation } from "src/app/customer/interfaces/iReservation";
import { IFlight } from "../interfaces/iFlight";

@Component({
    selector: 'app-edit-reservations-dialog',
    templateUrl: './edit-reservations-dialog.component.html',
    styleUrls: ['./edit-reservations-dialog.component.scss']
})
export class EditReservationsDialogComponent implements OnInit {
    reservations: IReservation[];
    configuration: boolean;
    constructor(
        private checkoutService: CheckoutService,
        public dialogRef: MatDialogRef<EditReservationsDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {flight: IFlight}
        ) {
            this.reservations = [] as IReservation[];
            this.configuration = false;
        }
    ngOnInit(): void {
        this.checkoutService.getFlightReservations(this.data.flight.id).subscribe(seats => {
            this.reservations = seats;
            this.configuration = true;
        },
        error => {
            console.log(error);
        });
    }

    onClickEditReservation(reservation: IReservation) {
        console.log(reservation);
    }
    
}