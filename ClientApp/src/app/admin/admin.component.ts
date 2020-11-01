import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { IUser } from '../login/interfaces/iUser';
import { UserService } from '../services/user.service';


@Component({ templateUrl: 'admin.component.html' })
export class AdminComponent implements OnInit {
    loading = false;
    users: IUser[] = [];

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loading = true;
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.loading = false;
            this.users = users;
        });
    }
}
