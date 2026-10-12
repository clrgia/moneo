import { Component, computed, input } from '@angular/core';
import { DecimalPipe, DatePipe, TitleCasePipe} from '@angular/common';

@Component({
  imports: [DecimalPipe, DatePipe, TitleCasePipe],
  selector: 'app-table',
  templateUrl: './table.html',
})
export class Table {
  public label = input.required<string>();
  public date = input.required<Date>();
  public amount = input.required<number>();
  public color = computed<string>(() => this.amount() < 0 ? 'text-red-700' : 'text-green-600');
}
