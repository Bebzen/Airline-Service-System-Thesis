import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication.service';
import { IUser } from './interfaces/iUser';
import { Role } from './interfaces/Role';
import { LoginService } from './services/loginService';

@Component ({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
    credentials: ICredentials;
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    user: IUser;
    returnUrl: string;
    returnUrlAdmin: string;
    error = '';

    constructor (
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService) {
            if (this.authenticationService.userValue) {
                this.router.navigate(['/']);
                this.credentials.password = '';
                this.credentials.username = '';
            }

    }

    ngOnInit () {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.returnUrlAdmin = this.route.snapshot.queryParams['returnUrl'] || '/admin';
    }

    get f() {
        return this.loginForm.controls;
    }

    onSubmit() {
        this.submitted = true;
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
        this.loading = true;
        this.authenticationService.login(this.f.username.value, this.f.password.value)
            .pipe(first())
            .subscribe(
                data => {
                    if (data.role === Role.Admin) {
                        this.router.navigate([this.returnUrlAdmin]);
                    } else {
                        this.router.navigate([this.returnUrl]);
                    }
                },
                error => {
                    this.error = error;
                    this.loading = false;
                }
            );
    }
}
