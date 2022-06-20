import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TwitterCredential } from 'src/app/_interfaces/TwitterCredential';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class TwitterRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService)
  { }

  // public GetUserTwitterCredential = (route: string,  twitterCredential: TwitterCredential) => {
  //   return this.http.post<TwitterCredential>(this.createCompleteRoute(route, this.envUrl.urlAddress), twitterCredential, this.generateHeaders());
  // }

  public GetUserTwitterCredential = (route: string) => {
    return this.http.get<TwitterCredential>(this.createCompleteRoute(route, this.envUrl.urlAddress));
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
