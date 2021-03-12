import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { IReservation } from '../customer/interfaces/iReservation';
import { FlightEditDialogComponent } from '../dispatcher/flight-edit-dialog/flight-edit-dialog.component';
import { ICrew } from '../dispatcher/interfaces/iCrew';
import { IFlight } from '../dispatcher/interfaces/iFlight';
import { IUser } from '../login/interfaces/iUser';
import { AuthenticationService } from '../services/authentication.service';
import { PilotService } from './services/pilot.service';

@Component({
    templateUrl: 'pilot.component.html',
    styleUrls: ['./pilot.component.scss']
})

export class PilotComponent implements OnInit {

    crews: ICrew[] = [];
    user: IUser;
    flights: IFlight[] = [];
    filteredFlights: IFlight[] = [];
    flightFilter: string;

    ngOnInit(): void {
        this.user = this.authenticationService.userValue;
        this.pilotService.getAllFlights(this.user.id).subscribe(flights => {
            this.flights = flights;
            this.filteredFlights = flights;
        },
        error => {
            console.log(error);
        });
    }
    constructor (
        private authenticationService: AuthenticationService,
        private pilotService: PilotService,
        public dialog: MatDialog
    ) {

    }
    onClickFilterFlights() {
        this.filteredFlights = this.performFlightFilter(this.flightFilter);
    }

    performFlightFilter(filterFlight: string) {
        if (filterFlight == null) {
            filterFlight = '';
        }
        filterFlight = filterFlight.toLocaleLowerCase();
        function filterResults(flight: IFlight) {
            return (
                (flight.flightNumber.toLocaleLowerCase().indexOf(filterFlight) !== -1) ||
                (flight.startingAirportName.toLocaleLowerCase().indexOf(filterFlight) !== -1) ||
                (flight.flightDate.toString().indexOf(filterFlight) !== -1)
            );
        }
        const filtered = this.flights.filter(filterResults);
        return filtered;
    }

    onClickEditFlight(flight: IFlight) {
        this.dialog.open(FlightEditDialogComponent,
            {
                width: '50%',
                data: { flight: flight, crews: this.crews, isPilot: true}
            });
    }
}
