import { Injectable } from '@angular/core';
import {Theme} from '../../../feature/themes/theme';
import {Observable, of} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FakeThemeService {

  themes: Theme[] = []

  constructor() {
    this.themes = [
      {
        id: 1,
        title: "Divertissement"
      },
      {
        id: 2,
        title: "Art et littérature"
      },
      {
        id: 3,
        title: "Géographie"
      },
      {
        id: 4,
        title: "Histoire"
      },
      {
        id: 5,
        title: "Sport et loisir"
      },
      {
        id: 6,
        title: "Science"
      }
    ]
  }

  getAll(): Observable<Theme[]> {
    return of(this.themes);
  }

  getById(id: number): Theme {
    for (let theme of this.themes) {
      if (theme.id.toString().toLowerCase()===id.toString().toLowerCase()) {
        return theme;
      }
    }
    return {id:0,title:''}
  }
}
