import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './services/loginService';

@Component ({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent {
    invalidLogin: boolean;
    credentials: ICredentials;

    constructor (private router: Router, private http: HttpClient, private loginService: LoginService) {
    }

    login (form: NgForm) {
        this.credentials = {
            'username': form.value.username,
            'password': form.value.password
        };
        this.loginService.login(this.credentials).subscribe(result => {
                const token = result.token;
                localStorage.setItem('jwt', token);
                this.invalidLogin = false;
                console.log(result);
            }, err => {
                this.invalidLogin = true;
            });
    }
}
