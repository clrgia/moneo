import { Service, inject } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { IAccount } from '../models/account';
@Service()
export class Operations {
  private http = inject(HttpClient);
  readonly apiUrl: string = environment.apiUrl;
}
