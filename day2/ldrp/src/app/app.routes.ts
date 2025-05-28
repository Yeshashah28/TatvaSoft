import { Routes } from '@angular/router';
import { Menu1Component } from "./menu1/menu1.component";
import { Menu2Component } from "./menu2/menu2.component";


export const routes: Routes = [
    {path: "menu1",component:Menu1Component},
    {path:"menu2", component:Menu2Component},
    {path:"**",redirectTo:"menu1"}, 
];
