import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatCardModule,
  MatButtonModule,
} from '@angular/material';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [// DI component here.
    AppComponent 
  ],
  imports: [// DI module here.
    BrowserModule,
    MatButtonModule,
    MatCardModule,
    HttpClientModule
  ],
  providers: [/* register services here*/], 
  bootstrap: [AppComponent]
})
export class AppModule { }
