import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  isCollapsed: boolean = false;
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  logOut = () => {
    localStorage.removeItem("jwt");
    this.isUserAuthenticated();
    this.router.navigate(["login"]);
  }

  isUserAuthenticated = (): boolean => {
    return false
  }

}
