import { Inject, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IUser } from 'src/app/login/interfaces/iUser';
import { ICrew } from '../interfaces/iCrew';
import { DispatcherService } from '../services/dispatcher.service';

@Component({
    selector: 'app-crew-edit-dialog',
    templateUrl: './crew-edit-dialog.component.html',
    styleUrls: ['./crew-edit-dialog.component.scss']
})
export class CrewEditDialogComponent {

    error = '';
    _selectionError = '';
    constructor(
        private dispatcherService: DispatcherService,
        public dialogRef: MatDialogRef<CrewEditDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {crew: ICrew, pilots: IUser[]}
        ) {
        }

    onClickEditCrew(crew: ICrew) {
        this.dispatcherService.editCrew(crew).subscribe(
            result => {
                this.dialogRef.close();
            },
            error => {
                console.log(error);
            }
        );
    }

    selectPilotCheck(): boolean {
        if (this.data.crew.captain === null) {
            this.data.crew.captain.id = -1;
        }
        if (this.data.crew.firstOfficer === null) {
            this.data.crew.firstOfficer.id = -2;
        }
        if (this.data.crew.secondOfficer === null) {
            this.data.crew.secondOfficer.id = -3;
        }
        if (
            (this.data.crew.captain.id === this.data.crew.firstOfficer.id) ||
            (this.data.crew.captain.id === this.data.crew.secondOfficer.id) ||
            (this.data.crew.firstOfficer.id === this.data.crew.secondOfficer.id)
        ) {
            this._selectionError = 'You cannot assign one pilot to two different spots!';
            return false;
        }
        return true;
    }

    public pilotComparisonFunction = function( option, value ): boolean {
        return option.id === value.id;
    };
}
