import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { UserRepositoryService } from 'src/app/shared/services/user-repository.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  User: any;
  constructor(private repo:UserRepositoryService) { }

  ngOnInit(): void {
    //TODO: this will be fixed later;
  }

}
