import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Menu1Service {

  getMessage() {
    return 'Hello from DataService!';
  }
}
