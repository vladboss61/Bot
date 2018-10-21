import { Component, Inject } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title: string;

  constructor(http: HttpClient){
    http.get('api/Bot/GetName', {responseType: 'text'}).subscribe(result => {
      this.title = result;
    }, error => console.error(error));
  }
}

class Bot{
  name: string;
}
