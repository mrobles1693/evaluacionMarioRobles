import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { PrincipalPersonalComponent } from './personal/principal-personal/principal-personal.component';
import { PersonalModule } from './personal/personal.module';
import { MaterialModule } from './material/material.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    PersonalModule,
    MaterialModule,
    RouterModule.forRoot([
     { path: '', component: PrincipalPersonalComponent, pathMatch: 'full' },
    ]),
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }