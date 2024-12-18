import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IquizzList} from '../../../feature/quizz/list-quizz/iquizz-list';

@Injectable({
  providedIn: 'root'
})
export class QuizzListService {

  private apiUrl = 'http://localhost:5000/v1/quizzes';

  constructor(private http: HttpClient) { }

  getAllQuizzes(): Observable<IquizzList[]> {
    return this.http.get<IquizzList[]>(this.apiUrl);
  }

  // getById(id: number):IquizzList {
  //   return {id: 0, title: "", themeId:1};
  // }
}
