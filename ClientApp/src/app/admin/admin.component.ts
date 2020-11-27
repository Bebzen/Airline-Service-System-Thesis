import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { first } from 'rxjs/operators';
import { IUser } from '../login/interfaces/iUser';
import { Role } from '../login/interfaces/Role';
import { UserService } from '../services/user.service';
import { AdministratorService } from './services/administrator.service';
import { UserEditDialogComponent } from './user-edit-dialog/user-edit-dialog.component';


@Component({
    templateUrl: 'admin.component.html',
    styleUrls: ['./admin.component.scss']})

export class AdminComponent implements OnInit {
    loading = false;
    public newUser: IUser;
    users: IUser[] = [];

    constructor(private userService: UserService, private administratorService: AdministratorService, public dialog: MatDialog) {
        this.newUser = {} as IUser;
    }

    ngOnInit() {
        this.loading = true;
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.loading = false;
            this.users = users;
        });
    }

    onClickCreateUser() {
        console.log(this.newUser);
        this.newUser.phoneNumber = 123;
        this.administratorService.createUser(this.newUser).subscribe(
            result => {
                console.log(result);
            },
            error => {
                console.log(error);
            }
        );
    }

    onClickEditUser(user: IUser) {
        this.dialog.open(UserEditDialogComponent,
            {width: '50%',
             data: user});

    }

    onClickDeleteUser(user: IUser) {
        this.administratorService.deleteUser(user.id).subscribe(
            result => {
                console.log(result);
            },
            error => {
                console.log(error);
            }
        );

    }
}
