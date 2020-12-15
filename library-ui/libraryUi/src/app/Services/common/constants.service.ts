import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstantsService {
  readonly usersApiUrl: string = 'http://localhost:49940/Api/Account/';
  readonly apiUrl: string = 'http://localhost:50455/a/';

  constructor() { }
}
