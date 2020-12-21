import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IUser } from 'src/app/login/interfaces/iUser';
import { AdministratorService } from '../services/administrator.service';

@Component({
    selector: 'app-user-edit-dialog',
    templateUrl: './user-edit-dialog.component.html',
    styleUrls: ['./user-edit-dialog.component.scss']
})
export class UserEditDialogComponent implements OnInit {

    error = '';

    constructor(private administratorService: AdministratorService, public dialogRef: MatDialogRef<UserEditDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: IUser) {
        }
    ngOnInit(): void {

    }

    onNoClick(): void {
        this.dialogRef.close();
    }

    onClickEditUser(user: IUser) {
        this.administratorService.editUser(user).subscribe(
            result => {
                console.log(result);
            },
            error => {
                this.error = error;
            }
        );
    }
}