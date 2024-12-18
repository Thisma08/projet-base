import {Question} from '../question/question';

export interface Quizz {
  id: number;
  title: string;
  description: string;
  theme: { id: number; title: string };
  questions: Question[];
  user: { id: number; username: string; email: string; role: string };
}
