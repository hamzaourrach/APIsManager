import { User } from './../../_interfaces/user.model';
import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticatedResponse } from 'src/app/_interfaces/AuthenticatedResponse';
import { LoginModel } from 'src/app/_interfaces/LoginModel';
@Injectable({
  providedIn: 'root'
})
export class UserRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService)
  { }

  public getUser = (route: string) => {
    return this.http.get<User>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getUsers = (route: string) => {
    return this.http.get<User[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public createUser = (route: string, user: User) => {
    return this.http.post<User>(this.createCompleteRoute(route, this.envUrl.urlAddress), user, this.generateHeaders());
  }

  public createUserToken = (route: string, loginModel: LoginModel) => {
    return this.http.post<AuthenticatedResponse>(this.createCompleteRoute(route, this.envUrl.urlAddress), loginModel, this.generateHeaders());
  }

  public updateUser = (route: string, user: User) => {
    return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), user, this.generateHeaders());
  }

  public deleteUser = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
