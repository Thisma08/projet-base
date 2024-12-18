import { Injectable } from '@angular/core';
import {Observable, of} from 'rxjs';
import {Theme} from '../../../feature/themes/theme';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private apiUrl = 'http://localhost:5000/v1/themes';

  constructor(private http: HttpClient) { }

  getAllThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>(this.apiUrl);
  }

  getById(id: number): Theme {
    return {id: 0, title: ""};
  }
}
