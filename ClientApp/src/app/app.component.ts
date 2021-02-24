import { Component } from '@angular/core';
import { InnerSubscriber } from 'rxjs/internal/InnerSubscriber';
import { IUser } from './login/interfaces/iUser';
import { Role } from './login/interfaces/Role';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  user: IUser;
  title = 'app';
  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.user.subscribe(x => this.user = x);
  }

  get isAdmin() {
    return this.user && this.user.role === Role.Admin;
  }

  get isDispatcher() {
    return this.user && this.user.role === Role.Dispatcher;
  }

  logout() {
    this.authenticationService.logout();
  }

}
