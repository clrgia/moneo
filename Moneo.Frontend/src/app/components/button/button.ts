import { Component, computed, input } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-button',
  styleUrl: './button.css',
  templateUrl: './button.html',
})
export class Button {
  public text = input.required<string>();
  public value = input.required<boolean>();
  public buttonClass = computed<string>(() => {
    return this.value() ? 'green' : 'red';
  });
}
