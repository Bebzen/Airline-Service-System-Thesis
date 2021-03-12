import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatCheckboxModule, MatDatepickerModule, MatDialogModule, MatDividerModule, MatExpansionModule, MatFormFieldModule, MatIconModule,
    MatInputModule, MatSelectModule, MatToolbarModule } from '@angular/material';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';

@NgModule ({
    declarations: [

    ],
    imports: [
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule,
        MatMomentDateModule,
        MatDatepickerModule,
        NgxMaterialTimepickerModule.setLocale('pl-PL'),
        MatDividerModule
    ],
    exports: [
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        ReactiveFormsModule,
        FormsModule,
        MatSelectModule,
        MatDialogModule,
        MatDatepickerModule,
        MatMomentDateModule,
        MatCheckboxModule,
        NgxMaterialTimepickerModule,
        MatDividerModule
    ],
    providers: [
        {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {useUTC: true}}
    ]
})

export class SharedModule { }
