import { Component } from '@angular/core';
import { Button } from '../button/button';

@Component({
  imports: [Button],
  selector: 'app-drawer',
  styleUrl: './drawer.css',
  templateUrl: './drawer.html',
})
export class Drawer {
  public buttons = [
    { label: 'Overview', linkTo: '/', icon: 'overview' },
    { label: 'Accounts', linkTo: '/accounts', icon: 'wallet' },
  ];

}
