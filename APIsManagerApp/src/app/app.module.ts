import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { UserModule } from './user/user.module';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './guards/auth.guard';
import { SignUpComponent } from './sign-up/sign-up.component';
import { HeaderNavbarComponent } from './header-navbar/header-navbar.component';
import { LeftNavbarComponent } from './left-navbar/left-navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TwitterSettingsComponent } from './twitter/twitter-settings/twitter-settings.component';
import { InfopanelTwtCredentialComponent } from './twitter/infopanel-twt-credential/infopanel-twt-credential.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    NotFoundComponent,
    InternalServerComponent,
    LoginComponent,
    SignUpComponent,
    HeaderNavbarComponent,
    LeftNavbarComponent,
    DashboardComponent,
    TwitterSettingsComponent,
    InfopanelTwtCredentialComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    UserModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
