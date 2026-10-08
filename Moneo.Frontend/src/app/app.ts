import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Button } from './components/button/button';

@Component({
  imports: [RouterOutlet, Button],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('Moneo.Frontend');
  public value = signal(true);
  constructor() {
    setInterval(() => {
      this.value.set(!this.value());
    }, 1000);
  }
}
