import {Component, EventEmitter, Input, Output} from '@angular/core';
import {DtoQuestionInput} from '../create-question/dto-question-input';
import {DtoQuestionOutput} from './dto-question-output';

@Component({
  selector: 'app-list-questions',
  standalone: true,
  imports: [],
  templateUrl: './list-questions.component.html',
  styleUrl: './list-questions.component.css'
})
export class ListQuestionsComponent {

  @Input()
  questions: DtoQuestionOutput[] = [];

  @Output()
  questionDeleted: EventEmitter<DtoQuestionOutput> = new EventEmitter();

  deleteQuestion(question: DtoQuestionOutput) {
    this.questionDeleted.emit(question)
  }
}
