import {Component, OnInit} from '@angular/core';
import {CreateQuestionComponent} from "../../question/create-question/create-question.component";
import {Theme} from '../../themes/theme';
import {QuizzListService} from '../../../shared/services/list-quizz/quizz-list.service';
import {IquizzList} from './iquizz-list';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {IquizzListService} from './iquizz-list.service';
import {ThemeService} from '../../../shared/services/theme/theme.service';

@Component({
  selector: 'app-list-quizz',
  standalone: true,
  imports: [
    CreateQuestionComponent,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './list-quizz.component.html',
  styleUrl: './list-quizz.component.css'
})
export class ListQuizzComponent implements OnInit {
  quizzs:IquizzList[]=[];
  searchTerm: string="";
  filteredQuizzs: IquizzList[] = [];
  typeFiltre:number=1;
  themes: Theme[] = [];

  constructor(private _quizService: QuizzListService, private _themeService: ThemeService) {

  }

  ngOnInit(): void {
    //this._quizService.getQuizzs().subscribe(quizzsFromServer => this.quizzs = quizzsFromServer);
    this.loadQuizzes();
    this.loadThemes();
  }
//this.quizz.theme = this._themeService.getById(this.themeId)

  loadQuizzes():void {
    this._quizService.getAllQuizzes().subscribe((data: IquizzList[]) => {
      this.quizzs = data;
      this.filteredQuizzs = data;
    })
  }

  resetFilter() {
    this.searchTerm="";
  }
  filterQuizzes() {
    const term = this.searchTerm.toLowerCase().trim();
    if (this.typeFiltre == 1)
      this.filteredQuizzs = this.quizzs.filter(quizz => quizz.title.toLowerCase().includes(term));

    if (this.typeFiltre == 3)
      this.filteredQuizzs = this.quizzs.filter(quizz => quizz.theme.title.toLowerCase().includes(term));

    if (this.typeFiltre == 2)
      this.filteredQuizzs = this.quizzs.filter(quizz => quizz.description.toLowerCase().includes(term));
  }


  loadThemes():void {
    this._themeService.getAllThemes().subscribe((data: Theme[]) => {
      this.themes = data;
    })
  }

}
