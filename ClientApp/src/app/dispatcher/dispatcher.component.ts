import { Component, OnInit} from '@angular/core';
import { MatDialog } from '@angular/material';
import { UserEditDialogComponent } from '../admin/user-edit-dialog/user-edit-dialog.component';
import { IUser } from '../login/interfaces/iUser';
import { CrewEditDialogComponent } from './crew-edit-dialog/crew-edit-dialog.component';
import { ICrew } from './interfaces/iCrew';
import { DispatcherService } from './services/dispatcher.service';

@Component({
    templateUrl: 'dispatcher.component.html',
    styleUrls: ['./dispatcher.component.scss']
})

export class DispatcherComponent implements OnInit {

    crewname = '';
    _selectionError = '';
    errors = '';
    selectedCaptainId = -1;
    selectedFirstOfficerId = -2;
    selectedSecondOfficerId = -3;
    addError = '';
    addResultValid = '';
    newCrew: ICrew;
    crewFilter: string;

    deleteResultValid = '';

    crews: ICrew[] = [];
    filteredCrews: ICrew[] = [];
    pilots: IUser[] = [];
    filteredPilots: IUser[] = [];

    constructor(private dispatcherService: DispatcherService, public dialog: MatDialog) {
        this.newCrew = {} as ICrew;
        this.crewFilter = '';
    }

    ngOnInit(): void {
        this.dispatcherService.getAllPilots().subscribe(users => {
            this.pilots = users;
        },
        error => {
            console.log(error);
        });
        this.dispatcherService.getAllCrews().subscribe(crews => {
            this.crews = crews;
            this.filteredCrews = crews;
        });
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
            this._selectionError = 'You cannot assign one pilot to two different spots!';
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
                this.deleteResultValid = 'User Deleted.';
                this.ngOnInit();
            }
        );
    }

    onClickCreateCrew(): void {
        if (this.selectPilotCheck()) {
            this.dispatcherService.createCrew(this.newCrew).subscribe(result => {
                this.addResultValid = 'Crew Created';
            },
            error => {
                this.addError = error;
            });
        }
    }
}
