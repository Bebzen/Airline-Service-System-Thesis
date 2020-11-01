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

  constructor(private userService: UserService, private authenticationService: AuthenticationService) {
    this.user = this.authenticationService.userValue;
    }
  ngOnInit() {
    this.loading = true;
    this.userService.getById(this.user.id).pipe(first()).subscribe(user => {
      this.loading = false;
      this.userFromApi = user;
      console.log(user);
    });
  }

}
