import {Component, EventEmitter, inject, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {DtoQuestionInput} from './dto-question-input';

@Component({
  selector: 'app-create-question',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './create-question.component.html',
  styleUrl: './create-question.component.css'
})
export class CreateQuestionComponent {
  private _fb: FormBuilder = inject(FormBuilder);

  @Output()
  questionCreated: EventEmitter<DtoQuestionInput> = new EventEmitter();

  questionForm: FormGroup = this._fb.group({
    title: new FormControl('', [Validators.required]),
    correctAnswer: new FormControl('', [Validators.required]),
    wrongAnswers: this._fb.group({
      answer1: new FormControl('', [Validators.required]),
      answer2: new FormControl('', [Validators.required]),
      answer3: new FormControl('', [Validators.required])
    })
  });

  createQuestion() {
    let question: DtoQuestionInput = {
      title: this.questionForm.value.title,
      rightAnswer: this.questionForm.value.correctAnswer,
      wrongAnswer1: this.questionForm.value.wrongAnswers.answer1,
      wrongAnswer2:this.questionForm.value.wrongAnswers.answer2,
      wrongAnswer3: this.questionForm.value.wrongAnswers.answer3,

    };

    this.questionCreated.emit(question);
  }

  autoComplete() {
    this.questionForm.setValue({
      title: "Question test",
      correctAnswer: "yes",
      wrongAnswers: {
        answer1: "no",
        answer2: "nope",
        answer3: "nada"
      }
    })
  }
}
