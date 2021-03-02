import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CrewEditDialogComponent } from './crew-edit-dialog/crew-edit-dialog.component';
import { DispatcherComponent } from './dispatcher.component';
import { FlightEditDialogComponent } from './flight-edit-dialog/flight-edit-dialog.component';
import { DispatcherService } from './services/dispatcher.service';

@NgModule({
    declarations: [
        DispatcherComponent,
        CrewEditDialogComponent,
        FlightEditDialogComponent
    ],
    imports: [
        SharedModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule
    ],
    providers: [DispatcherService],
    entryComponents: [
        CrewEditDialogComponent,
        FlightEditDialogComponent
    ]
})
export class DispatcherModule { }
