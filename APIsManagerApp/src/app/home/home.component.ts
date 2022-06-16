import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public welcomeMsg: string;
  constructor(private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    this.welcomeMsg = "Welcome to home Page";
  }


}
