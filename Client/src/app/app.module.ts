import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { PrimeNGModule } from './shared/prime-ng/prime-ng.modules';
import { MessageService } from 'primeng/api';

@NgModule({ declarations: [
        AppComponent,
        HomeComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        PrimeNGModule], providers: [MessageService, provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
