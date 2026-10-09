import { Component, computed, input } from '@angular/core';
import { DecimalPipe, DatePipe } from '@angular/common';

@Component({
  imports: [DecimalPipe, DatePipe],
  selector: 'app-table',
  styleUrl: './table.css',
  templateUrl: './table.html',
})
export class Table {
  public label = input.required<string>();
  public date = input.required<Date>();
  public amount = input.required<number>();
  public color = computed<string>(() => this.amount() < 0 ? 'text-red-700' : 'text-green-600');
}
