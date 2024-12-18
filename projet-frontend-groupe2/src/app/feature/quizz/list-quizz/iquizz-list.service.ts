import { Injectable } from '@angular/core';
import {delay, Observable, of} from "rxjs";
export interface IquizzList {
  title: string;
  description: string;
  color: string;
  theme: string;
}
@Injectable({
  providedIn: 'root'
})
export class IquizzListService {

  constructor() { }

  getQuizzs(): Observable<IquizzList[]>
  {
    return of([
      {title:"nomQuiz1", description:"desc1", color:"red", theme:"écologie"},
      {title:"nomQuiz2", description:"desc2", color:"green", theme:"politique"},
      {title:"nomQuiz3", description:"desc3", color:"blue", theme:"informatique"},
    ]);
  }
}
