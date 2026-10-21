import { Component, input } from '@angular/core';
import { DecimalPipe, TitleCasePipe } from '@angular/common';

@Component({
  imports: [DecimalPipe, TitleCasePipe],
  selector: 'app-stat',
  templateUrl: './stat.html',
})
export class Stat {


  public label = input.required<string>();
  public amount = input.required<number>();
  public type = input.required<string>();
}
