import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TwitterRepositoryService } from 'src/app/shared/services/twitter-repository.service';
import { TwitterCredential } from 'src/app/_interfaces/TwitterCredential';

@Component({
  selector: 'app-twitter-settings',
  templateUrl: './twitter-settings.component.html',
  styleUrls: ['./twitter-settings.component.css']
})
export class TwitterSettingsComponent implements OnInit {

  invalidData : boolean = false;
  twitterConfigured: boolean = false;
  twitterCredential : TwitterCredential ={ IdUser: 0, ACCESS_TOKEN : '', ACCESS_TOKEN_SECRET :'',CONSUMER_KEY : '', CONSUMER_SECRET : ''};
  constructor(private router: Router, private http: HttpClient, private jwtHelper: JwtHelperService,private repo:TwitterRepositoryService) { }


  ngOnInit(): void {
  }

  AddCredential = ( form: NgForm) => {
    if (form.valid) {
      const userId = localStorage.getItem("userid");
      this.twitterCredential.IdUser = Number(userId);
      //console.log(this.user.email);
      this.repo.createCredential('Twitter/api/twitter', this.twitterCredential)
      .subscribe({
        next: (response: TwitterCredential) => {
          this.invalidData = false;
          //this.createToken();
          console.log(response);
        },
        error: (err: HttpErrorResponse) => this.invalidData = true
      })
    }
  }
}
