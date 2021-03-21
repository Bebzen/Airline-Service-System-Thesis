import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { first } from 'rxjs/operators';
import { IUser } from '../login/interfaces/iUser';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  loading = false;
  user: IUser;
  userFromApi: IUser;
  userChanges: IUser;
  error = '';
  resultValid = '';

  constructor(private userService: UserService, private authenticationService: AuthenticationService) {
    this.user = this.authenticationService.userValue;
    this.userChanges = {} as IUser;
    }
  ngOnInit() {
    this.loading = true;
    this.userService.getById(this.user.id).pipe(first()).subscribe(user => {
      this.loading = false;
      this.userFromApi = user;
      this.userChanges = user;
    });
  }
  
  onClickEditUser() {
    this.userService.editUser(this.userChanges).subscribe(user => {
      this.resultValid = 'Data edited successfuly.'
    },
    error => {
      this.error = `Data could not be edited.`
    })
  }

}
