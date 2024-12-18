import {DtoQuestionOutput} from '../../question/list-questions/dto-question-output';
import {Theme} from '../../themes/theme';

export interface DtoQuizzInput {
  id: number;
  title:string
  description:string
  answerTime:number
  theme:Theme
  questions: DtoQuestionOutput[]
}
