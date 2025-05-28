import { Component } from '@angular/core';
import { Menu1Service } from '../service/menu1.service';

@Component({
  selector: 'app-menu1',
  standalone: true,
  imports: [],
  templateUrl: './menu1.component.html',
  styleUrl: './menu1.component.css'
})
export class Menu1Component {
 message:string;
 constructor(private menu1service:Menu1Service){
  this.message=this.menu1service.getMessage();
 }
}
