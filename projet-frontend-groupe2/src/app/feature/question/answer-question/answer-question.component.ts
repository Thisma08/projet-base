import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DtoQuestionInput} from '../create-question/dto-question-input';
import {FormsModule} from '@angular/forms';
import {map, takeWhile, tap, timer} from 'rxjs';
import {AsyncPipe, DatePipe} from '@angular/common';

@Component({
  selector: 'app-answer-question',
  standalone: true,
  imports: [
    FormsModule,
    AsyncPipe,
    DatePipe
  ],
  templateUrl: './answer-question.component.html',
  styleUrl: './answer-question.component.css'
})
export class AnswerQuestionComponent implements OnInit{

  symbols = [
    "♠️",
    "♥️",
    "♦️",
    "♣️",
  ]

  @Input()
  question: DtoQuestionInput| null = null;

  @Input()
  competitive: boolean = false;

  @Input()
  seconds: number = 15;

  answers: string[]= []
  timer: any = null;

  @Output()
  questionAnswered: EventEmitter<boolean> = new EventEmitter();

  ngOnInit() {
    if(this.question != null){
      this.answers.push(this.question.rightAnswer);
      //this.question.wrongAnswers.forEach(answer => this.answers.push(answer));
      this.answers.sort(() => Math.random() - 0.5);
      this.timer = this.seconds;
      if (this.competitive) this.countdown();
    }
  }

  answerQuestion(answer: string) {
    this.questionAnswered.emit(answer === this.question!.rightAnswer)
    if(this.question != null){
      this.answers=[];
      this.answers.push(this.question.rightAnswer);
      //this.question.wrongAnswers.forEach(answer => this.answers.push(answer));
      this.answers.sort(() => Math.random() - 0.5);
      if(this.competitive) this.countdown();
    }
  }

  countdown() {
    //Lance un timer toutes les secondes
    this.timer = timer(0, 1000).pipe(
      //map => Calcule en millisecondes le temps restant
      map(n => (this.seconds - n) * 1000),
      //takeWhile => signale que
      takeWhile(n => n >= 0),
      tap(n => {
        if(n === 0) this.answerQuestion("///");
      })
    );
  }
}
