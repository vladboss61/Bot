import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatCardModule,
  MatButtonModule,
} from '@angular/material';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [// DI component here.
    AppComponent 
  ],
  imports: [// DI module here.
    BrowserModule,
    MatButtonModule,
    MatCardModule
  ],
  providers: [/* register services here*/], 
  bootstrap: [AppComponent]
})
export class AppModule { }
