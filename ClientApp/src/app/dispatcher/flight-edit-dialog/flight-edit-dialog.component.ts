import * as moment from 'moment';
import { Moment } from 'moment';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, _MatTabGroupBase } from '@angular/material';
import { IFlight } from '../interfaces/iFlight';
import { PlaneType } from '../interfaces/PlaneType';
import { DispatcherService } from '../services/dispatcher.service';
import { ICrew } from '../interfaces/iCrew';

@Component({
    selector: 'app-flight-edit-dialog',
    templateUrl: './flight-edit-dialog.component.html',
    styleUrls: ['./flight-edit-dialog.component.scss']
})
export class FlightEditDialogComponent {
    error = '';
    planeTypes;
    constructor (
        private dispatcherService: DispatcherService,
        public dialogRef: MatDialogRef<FlightEditDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {flight: IFlight, crews: ICrew[]}){
            this.planeTypes = this.enumSelector(PlaneType);
        }

        enumSelector(definition) {
            return Object.keys(definition)
              .map(key => ({ value: definition[key], title: key }));
          }

        onClickEditFlight(flight: IFlight) {
            this.dispatcherService.editFlight(flight).subscribe(
                result => {
                    this.dialogRef.close();
                },
                error => {
                    console.log(error);
                    this.error = error;
                }
            );
        }
        public crewComparisonFunction = function( option, value ): boolean {
            return option.id === value.id;
        }
}
