import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ldrp';
  name='';
  imageurl="C:/Users/Yesha/Downloads/og bg.png";
  items=["apple","Banana","orange"];
  clickme(){
    console.log("button pressed");
  }
}
