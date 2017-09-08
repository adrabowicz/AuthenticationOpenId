import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { LoginComponent } from './login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { AppDataService } from './services/app-data.service';
import { AppTokenService } from './services/app-token.service';

@NgModule({
  declarations: [
      AppComponent,
      WelcomeComponent,
      LoginComponent
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
      AppRoutingModule
  ],
  providers: [
      AppDataService,
      AppTokenService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
