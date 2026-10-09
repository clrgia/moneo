import { Component, input } from '@angular/core';
import { DecimalPipe } from '@angular/common';

@Component({
  imports: [DecimalPipe],
  selector: 'app-stat',
  styleUrl: './stat.css',
  templateUrl: './stat.html',
})
export class Stat {
  public label = input.required<string>();
  public amount = input.required<number>();
  public type = input.required<string>();
}
