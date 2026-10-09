import { Component } from '@angular/core';
import { Stat } from '../../components/stat/stat';

@Component({
  imports: [Stat],
  selector: 'app-overview-page',
  styleUrl: './overview-page.css',
  templateUrl: './overview-page.html',
})
export class OverviewPage {
  public stats = [
    { label: 'Compte courant', amount: 12564.25, type: 'Current' },
    { label: 'Livret A', amount: 18000.24, type: 'Savings' },
    { label: 'LEP', amount: 10000, type: 'Savings' }
  ];
}
