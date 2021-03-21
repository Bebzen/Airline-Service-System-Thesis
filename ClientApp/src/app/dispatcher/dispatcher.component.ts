import { Component, OnInit} from '@angular/core';
import { MatDialog } from '@angular/material';
import * as moment from 'moment';
import { Moment } from 'moment';
import { UserEditDialogComponent } from '../admin/user-edit-dialog/user-edit-dialog.component';
import { IUser } from '../login/interfaces/iUser';
import { CrewEditDialogComponent } from './crew-edit-dialog/crew-edit-dialog.component';
import { EditReservationsDialogComponent } from './edit-reservations-dialog/edit-reservations-dialog.component';
import { FlightEditDialogComponent } from './flight-edit-dialog/flight-edit-dialog.component';
import { ICrew } from './interfaces/iCrew';
import { IFlight } from './interfaces/iFlight';
import { PlaneType } from './interfaces/PlaneType';
import { DispatcherService } from './services/dispatcher.service';
/* tslint:disable: deprecation */
@Component({
    templateUrl: 'dispatcher.component.html',
    styleUrls: ['./dispatcher.component.scss']
})

export class DispatcherComponent implements OnInit {

    crewname = '';
    selectedCaptainId = -1;
    selectedFirstOfficerId = -2;
    selectedSecondOfficerId = -3;
    error = '';
    resultValid = '';
    newCrew: ICrew;
    crewFilter: string;
    newFlight: IFlight;
    flightFilter: string;
    planeTypes;

    newFlightDate: Moment;

    crews: ICrew[] = [];
    filteredCrews: ICrew[] = [];
    pilots: IUser[] = [];
    filteredPilots: IUser[] = [];
    flights: IFlight[] = [];
    filteredFlights: IFlight[] = [];

    constructor(
        private dispatcherService: DispatcherService,
        public dialog: MatDialog
        ) {
        this.newCrew = {} as ICrew;
        this.newFlight = {} as IFlight;
        this.crewFilter = '';
        this.planeTypes = this.enumSelector(PlaneType);
        this.newFlight.flightDate = moment().add(0, 'days');
    }

    ngOnInit(): void {

        this.dispatcherService.getAllPilots().subscribe(users => {
            this.pilots = users;
        });
        this.dispatcherService.getAllCrews().subscribe(crews => {
            this.crews = crews;
            this.filteredCrews = crews;
        });
        this.dispatcherService.getAllFlights().subscribe(flights => {
            this.flights = flights;
            this.filteredFlights = flights;
        });
    }

    enumSelector(definition) {
        return Object.keys(definition)
          .map(key => ({ value: definition[key], title: key }));
      }

    performCrewFilter(filterCrew: string) {
        if (filterCrew == null) {
            filterCrew = '';
        }
        filterCrew = filterCrew.toLocaleLowerCase();
        function filterResults(crew: ICrew) {
            return (
                (crew.crewName.toLocaleLowerCase().indexOf(filterCrew) !== -1) ||
                (crew.captain.lastName.toLocaleLowerCase().indexOf(filterCrew) !== -1) ||
                (crew.firstOfficer.lastName.toLocaleLowerCase().indexOf(filterCrew) !== -1) ||
                (crew.secondOfficer.lastName.toLocaleLowerCase().indexOf(filterCrew) !== -1));
        }
        const filtered = this.crews.filter(filterResults);
        return filtered;
    }
    onClickFilter() {
        this.filteredCrews = this.performCrewFilter(this.crewFilter);
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
                (flight.crew.crewName.toLocaleLowerCase().indexOf(filterFlight) !== -1) ||
                (flight.flightDate.toString().indexOf(filterFlight) !== -1)
            );
        }
        const filtered = this.flights.filter(filterResults);
        return filtered;
    }

    selectPilotCheck(): boolean {
        if (this.newCrew.captain === null) {
            this.newCrew.captain.id = -1;
        }
        if (this.newCrew.firstOfficer === null) {
            this.newCrew.firstOfficer.id = -2;
        }
        if (this.newCrew.secondOfficer === null) {
            this.newCrew.secondOfficer.id = -3;
        }
        if (
            (this.newCrew.captain.id === this.newCrew.firstOfficer.id) ||
            (this.newCrew.captain.id === this.newCrew.secondOfficer.id) ||
            (this.newCrew.firstOfficer.id === this.newCrew.secondOfficer.id)
        ) {
            this.error = 'You cannot assign one pilot to two different spots!';
            return false;
        }
        return true;
    }

    onPilotClick(user: IUser) {
        this.dialog.open(UserEditDialogComponent,
            {width: '50%',
             data: { user: user, disableEditing: true }
            });
    }

    onClickEditCrew(crew: ICrew) {
        this.dialog.open(CrewEditDialogComponent,
            {
                width: '50%',
                data: { crew: crew, pilots: this.pilots}
            });
    }

    onClickDeleteCrew(crew: ICrew) {
        this.dispatcherService.deleteCrew(crew.id).subscribe(
            result => {
                this.resultValid = 'Crew Deleted.';
                this.ngOnInit();
            },
            error => {
                this.error = `Couldn't delete the Crew.`
            });
    }

    onClickCreateCrew(): void {
        this.error = '';
        this.resultValid = '';
        if (!this.newCrew.captain || !this.newCrew.firstOfficer || !this.newCrew.secondOfficer || !this.newCrew.crewName) {
            this.error = `Some fields are empty.`
        } else {
            if (this.selectPilotCheck()) {
                this.dispatcherService.createCrew(this.newCrew).subscribe(result => {
                    this.resultValid = 'Crew Created.';
                    this.ngOnInit();
                },
                error => {
                    this.error = `Couldn't create the Crew.`
                });
            }
        }
    }

    onClickCreateFlight(): void {
        this.error = '';
        this.resultValid = '';
        this.newFlight.isApproved = false;
        this.newFlight.isCompleted = false;
        if (!this.newFlight.flightNumber || !this.newFlight.crew || !this.newFlight.startingAirportName || !this.newFlight.destinationAirportName ||
            !this.newFlight.flightDate || !this.newFlight.takeoffHour || !this.newFlight.landingHour || !this.newFlight.planeType || !this.newFlight.totalSeats) {
            this.error = `Some fields are empty.`
        } else {
            this.dispatcherService.createFlight(this.newFlight).subscribe(result => {
                this.ngOnInit();
                this.resultValid = `Flight Created.`;
            },
            error => {
                this.error = `Couldn't create the Flight.`
            });
        }
    }

    onClickEditFlight(flight: IFlight) {
        this.dialog.open(FlightEditDialogComponent,
            {
                width: '50%',
                data: { flight: flight, crews: this.crews, isPilot: false}
            });
    }

    onClickDeleteFlight(flight: IFlight) {
        this.dispatcherService.deleteFlight(flight.id).subscribe(result => {
            this.ngOnInit();
            this.resultValid = `Flight deleted.`
        },
        error => {
            this.error = `Couldn't delete the flight.`
        });
    }

    onClickViewReservations(flight: IFlight) {
        this.dialog.open(EditReservationsDialogComponent,
            {
                width: '50%',
                data: {flight: flight}
            });
    }
}
