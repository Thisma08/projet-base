import {Injectable, OnInit} from '@angular/core';
import {DtoQuizzInput} from '../../../feature/quizz/create-quizz/dto-quizz-input';

@Injectable({
  providedIn: 'root'
})
export class FakeQuizzService{
  private static readonly SESSION_STORAGE_KEY = 'quizz';
  quizzes: DtoQuizzInput[] = [];

  constructor() {
    this.quizzes = this.getAllQuizzes();
  }

  getAllQuizzes(): DtoQuizzInput[] {
    const rawNames: string = sessionStorage.getItem(FakeQuizzService.SESSION_STORAGE_KEY) || "[]";
    return JSON.parse(rawNames);
  }

  create(quizz: DtoQuizzInput) {
    quizz.id = this.quizzes.length;
    this.quizzes.push(quizz);
    sessionStorage.setItem(FakeQuizzService.SESSION_STORAGE_KEY, JSON.stringify(this.quizzes));
  }

  getQuizzById(id: number) : DtoQuizzInput | null {
    for (let quizz of this.quizzes) {
      if (quizz.id.toString().toLowerCase()===id.toString().toLowerCase()) {
        return quizz;
      }
    }
    return null;
  }
}
