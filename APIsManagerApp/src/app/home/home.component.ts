import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TwitterRepositoryService } from '../shared/services/twitter-repository.service';
import { TwitterCredential } from '../_interfaces/TwitterCredential';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  twitterConfigured: boolean = false;
  twitterCredential : TwitterCredential ={ IdUser: 0, ACCESS_TOKEN : '', ACCESS_TOKEN_SECRET :'',CONSUMER_KEY : '', CONSUMER_SECRET : ''};
  constructor(private router: Router, private http: HttpClient, private jwtHelper: JwtHelperService,private repo:TwitterRepositoryService) { }

  ngOnInit(): void {
    this.isTwitterConfigured();
  }

  isTwitterConfigured = (): boolean => {
    const userId = localStorage.getItem("userid");
    this.repo.GetUserTwitterCredential('Twitter/api/twitter/GetTwitterCredentialByUserId/'+userId)
      .subscribe({
        next: (response: TwitterCredential) => {
          var test = response;
          console.log(test);
          if(response.IdUser === 0)
          {
            return this.twitterConfigured;
          }
          else{
            this.twitterConfigured = true;
          }

        },
        error: (err: HttpErrorResponse) => this.twitterConfigured
      })

      return this.twitterConfigured;
  }


}
