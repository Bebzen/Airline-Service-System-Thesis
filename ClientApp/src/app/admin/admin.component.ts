import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { first } from 'rxjs/operators';
import { IUser } from '../login/interfaces/iUser';
import { UserService } from '../services/user.service';
import { AdministratorService } from './services/administrator.service';
import { UserEditDialogComponent } from './user-edit-dialog/user-edit-dialog.component';


@Component({
    templateUrl: 'admin.component.html',
    styleUrls: ['./admin.component.scss']
})

export class AdminComponent implements OnInit {
    loading = false;
    public newUser: IUser;
    users: IUser[] = [];
    filteredUsers: IUser[] = [];
    usernameFilter: string;
    lastNameFilter: string;
    addError = '';
    deleteError = '';
    deleteResultValid = '';
    addResultValid = '';

    constructor(private userService: UserService, private administratorService: AdministratorService, public dialog: MatDialog) {
        this.newUser = {} as IUser;
        this.usernameFilter = '';
        this.lastNameFilter = '';
    }

    performFilter(filterLastName: string, filterUsername: string): IUser[] {
        if (filterLastName == null) {
            filterLastName = '';
        }
        if (filterUsername == null) {
            filterUsername = '';
        }
        filterLastName = filterLastName.toLocaleLowerCase();
        filterUsername = filterUsername.toLocaleLowerCase();
        function filterResults(user: IUser) {
            return (user.lastName.toLocaleLowerCase().indexOf(filterLastName) !== -1) &&
                   (user.username.toLocaleLowerCase().indexOf(filterUsername) !== -1);
        }
        const filtered = this.users.filter(filterResults);
        return filtered;
    }

    onClickFilter() {
        this.filteredUsers = this.performFilter(this.lastNameFilter, this.usernameFilter);
    }

    ngOnInit() {
        this.loading = true;
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.loading = false;
            this.users = users;
            this.filteredUsers = users;
        });
    }

    onClickCreateUser() {
        this.administratorService.createUser(this.newUser).subscribe(
            result => {
                this.addResultValid = 'User Created.';
                this.ngOnInit();
            },
            error => {
                this.addError = error;
            }
        );
    }

    onClickEditUser(user: IUser) {
        this.dialog.open(UserEditDialogComponent,
            {
             width: '50%',
             data: { user: user, disableEditing: false },
            });
    }

    onClickDeleteUser(user: IUser) {
        this.administratorService.deleteUser(user.id).subscribe(
            result => {
                this.deleteResultValid = 'User Deleted.';
                this.ngOnInit();
            },
            error => {
                this.deleteError = error;
            }
        );

    }
}
