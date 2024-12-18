import {Component, Input, OnInit} from '@angular/core';
import {DtoQuizzInput} from '../create-quizz/dto-quizz-input';
import {QuizzService} from '../../../shared/services/quizz/quizz.service';
import {FakeQuizzService} from '../../../shared/services/quizz/fake-quizz.service';
import {DtoQuestionOutput} from '../../question/list-questions/dto-question-output';
import {AnswerQuestionComponent} from '../../question/answer-question/answer-question.component';

@Component({
  selector: 'app-play-quizz',
  standalone: true,
  imports: [
    AnswerQuestionComponent
  ],
  providers: [
    {provide: QuizzService,useClass: FakeQuizzService}
  ],
  templateUrl: './play-quizz.component.html',
  styleUrl: './play-quizz.component.css'
})
export class PlayQuizzComponent implements OnInit{

  @Input()
  idQuizz: number = 0;

  @Input()
  competitive: boolean = false;

  quizz: DtoQuizzInput | null = null;
  question: DtoQuestionOutput | null = null;

  idQuestion: number = 0;

  nbQuestionsBonnes = 0;
  finishedQuizz = false;
  pointsTotals = 0;

  constructor(private _quizzService: QuizzService) {
  }

  ngOnInit() {
    this.quizz = this._quizzService.getQuizzById(this.idQuizz)
    if(this.quizz!=null){
      this.quizz.questions.sort(() => Math.random() - 0.5);
      let question = this.quizz.questions.at(this.idQuestion)
      this.question = question != undefined ? question : null;
    }

  }

  nextQuestion(answeredRight: boolean) {

    if(answeredRight) this.nbQuestionsBonnes++
    let question = this.quizz!.questions.at(++this.idQuestion)
    this.question = question != undefined ? question : null;

    if(this.question === null){
      this.finishedQuizz = true;
      this.pointsTotals = this.nbQuestionsBonnes/this.quizz!.questions.length;
    }

  }
}
