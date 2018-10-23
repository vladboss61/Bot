import { Component, Inject } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {  map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title: string;
  public users: Observable<BotUser[]>;
  public http: HttpClient;

  constructor(http: HttpClient){
    http.get('api/bot/name', {responseType: 'text'}).subscribe(result => {
      this.title = result;
    }, error => console.error(error));

    this.http = http;
    this.users = this.getUsers();
  }

  public getUsers(): Observable<BotUser[]>{
    return this.http.get('api/bot/users')
      .pipe<BotUser[]>(map(re => re as BotUser[]));
  }
}

class BotUser{
  public chatId: number;
  public firstName: string;
}
