import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedResponse } from '../_interfaces/AuthenticatedResponse';
import { LoginModel } from '../_interfaces/LoginModel';
import { UserRepositoryService } from '../shared/services/user-repository.service'
import { User } from '../_interfaces/user.model';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['../login/login.component.css']
})
export class SignUpComponent implements OnInit {

  invalidSignUp: boolean;
  user: User = {email :'',password:'',fullName:'',description:'',id:0};
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

  signup = ( form: NgForm) => {
    if (form.valid) {
      console.log(this.user.email);
      this.repo.createUser('User/api', this.user)
      .subscribe({
        next: (response: User) => {
          //const token = response.token;
          //console.log(token);
          //localStorage.setItem("jwt", token);
          this.invalidSignUp = false;
          this.createToken();
        },
        error: (err: HttpErrorResponse) => this.invalidSignUp = true
      })
    }
  }

  createToken()
  {
    this.credentials.email = this.user.email;
    this.credentials.password = this.user.password;

    this.repo.createUserToken('api/Auth/login', this.credentials)
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          console.log(token);
          localStorage.setItem("jwt", token);
          this.router.navigate(["/"]);
        },
        error: (err: HttpErrorResponse) => this.invalidSignUp = true
      })
  }

}
