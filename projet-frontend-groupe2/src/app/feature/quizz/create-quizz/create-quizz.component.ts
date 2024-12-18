import {Component, OnInit} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {QuizzService} from "../../../shared/services/quizz/quizz.service";
import {ThemeService} from '../../../shared/services/theme/theme.service';
import {Theme} from '../../themes/theme';
import {CreateQuestionComponent} from '../../question/create-question/create-question.component';
import {DtoQuestionInput} from '../../question/create-question/dto-question-input';
import {ListQuestionsComponent} from '../../question/list-questions/list-questions.component';
import {DtoQuestionOutput} from '../../question/list-questions/dto-question-output';

@Component({
  selector: 'app-create-quizz',
  standalone: true,
  imports: [
    FormsModule,
    CreateQuestionComponent,
    ListQuestionsComponent
  ],
  templateUrl: './create-quizz.component.html',
  styleUrl: './create-quizz.component.css'
})
export class CreateQuizzComponent implements OnInit {
  themes: Theme[] = [];

  quizz = {
    title: "",
    description: "",
    theme: {
      id: 1
    },
    questions: [
      {
        questionText: "",
        correctChoice: "",
        incorrectChoice1: "",
        incorrectChoice2: "",
        incorrectChoice3: ""
      }
    ],
    user: {
      id: 1
    }
  };

  constructor(private _themeService: ThemeService, private _quizzService: QuizzService) {}

  ngOnInit(): void {
    this.loadThemes();
  }

  loadThemes():void {
    this._themeService.getAllThemes().subscribe((data: Theme[]) => {
      this.themes = data;
    })
  }



  resetForm()
  {
    this.quizz = {
      title: '',
      description: '',
      theme: {
        id: 1
      },
      questions: [
        {
          questionText: "",
          correctChoice: "",
          incorrectChoice1: "",
          incorrectChoice2: "",
          incorrectChoice3: ""
        }
      ],
      user: {
        id: 1
      }
    }

  }


  afficher() {
    console.log(this.quizz);
    this._quizzService.create(this.quizz).subscribe({
      next: (response) => {
        console.log('Quizz created successfully:', response);
        this.resetForm();
      },
      error: (error) => {
        console.error('Error creating quizz:', error);
      },
    });

  }
  addToList(question: DtoQuestionInput) {
    this.quizz.questions.push({
      correctChoice: question.rightAnswer,
      incorrectChoice1: question.wrongAnswer1,
      incorrectChoice2: question.wrongAnswer2,
      incorrectChoice3: question.wrongAnswer3,
      questionText: question.title,
    })
  }

  deleteQuestion(question: DtoQuestionOutput) {
    this.quizz.questions.splice(this.quizz.questions.indexOf(question), 1);
  }


  // createQuizz() {
  //   this.quizz.theme = this._themeService.getById(this.themeId)
  //   this._quizzService.create(this.quizz)
  //   this.quizz = {
  //     id: 0,
  //     title:"",
  //     description:"",
  //     theme: {
  //       id: Math.random(),
  //       title: ""
  //     },
  //     answerTime: 5,
  //     questions: []
  //   }
  // }

}
