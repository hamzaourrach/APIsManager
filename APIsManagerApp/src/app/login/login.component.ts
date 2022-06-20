import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedResponse } from '../_interfaces/AuthenticatedResponse';
import { LoginModel } from '../_interfaces/LoginModel';
import { UserRepositoryService } from '../shared/services/user-repository.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean;
  credentials: LoginModel = {email:'', password:''};
  constructor(private router: Router, private http: HttpClient, private jwtHelper: JwtHelperService,private repo:UserRepositoryService) { }
  ngOnInit(): void {

  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }

  login = ( form: NgForm) => {
    if (form.valid) {
      this.repo.createUserToken('api/Auth/login', this.credentials)
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          const idUser = response.idUser;
          console.log(response.idUser);
          localStorage.setItem("jwt", token);
          localStorage.setItem("userid", idUser);
          this.invalidLogin = false;
          this.router.navigate(["/"]);
        },
        error: (err: HttpErrorResponse) => this.invalidLogin = true
      })
    }
  }

}
