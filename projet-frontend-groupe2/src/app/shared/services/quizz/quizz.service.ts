import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {DtoQuizzInput} from '../../../feature/quizz/create-quizz/dto-quizz-input';
import {catchError, Observable, throwError} from 'rxjs';
import {Theme} from '../../../feature/themes/theme';
import {Quizz} from '../../../feature/quizz/quizz';

@Injectable({
  providedIn: 'root'
})
export class QuizzService {
  private apiUrl = 'http://localhost:5000/v1/quizzes';

  constructor(private http: HttpClient) {}

  getAllQuizzes(): Observable<Quizz[]> {
    return this.http.get<Quizz[]>(this.apiUrl);
  }

  create(quizz: any): Observable<any> {
    console.log(quizz)
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(this.apiUrl, quizz, httpOptions)
  }

  getQuizzById(id: number) : DtoQuizzInput | null {
    return null;
  }
}
