import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {CreateQuizzComponent} from './feature/quizz/create-quizz/create-quizz.component';
import {PlayQuizzComponent} from './feature/quizz/play-quizz/play-quizz.component';
import {ListQuestionsComponent} from './feature/question/list-questions/list-questions.component';
import {ListQuizzComponent} from './feature/quizz/list-quizz/list-quizz.component';
import {CreateUserComponent} from './feature/user/create-user/create-user.component';
import {ConnectUserComponent} from './feature/user/connect-user/connect-user.component';
import {CreateQuestionComponent} from './feature/question/create-question/create-question.component';
import {LoginComponent} from './feature/user/login/login.component';



@Component({
  selector: 'app-root',
  standalone: true,

  // imports: [RouterOutlet, CreateQuestionComponent, CreateQuizzComponent, PlayQuizzComponent],
  imports: [RouterOutlet, CreateQuizzComponent, PlayQuizzComponent, ListQuestionsComponent, ListQuizzComponent, CreateUserComponent, ConnectUserComponent, RouterLinkActive, RouterLink, LoginComponent],

  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ProjetAngular';
}
