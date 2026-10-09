import { Component, input } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-category',
  styleUrl: './category.css',
  templateUrl: './category.html',
})
export class Category {
  public label = input.required<string>();
  public percentage = input.required<number>();
}
