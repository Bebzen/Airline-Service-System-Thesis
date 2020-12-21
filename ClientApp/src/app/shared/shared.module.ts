import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatDialogModule, MatExpansionModule, MatFormFieldModule, MatIconModule,
    MatInputModule, MatSelectModule, MatToolbarModule } from '@angular/material';
import { UserEditDialogComponent } from '../admin/user-edit-dialog/user-edit-dialog.component';

@NgModule ({
    declarations: [

    ],
    imports: [
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule
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
        MatDialogModule
    ]
})

export class SharedModule { }