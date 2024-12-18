import { Routes } from '@angular/router';
import {CreateQuizzComponent} from './feature/quizz/create-quizz/create-quizz.component';
import {ListQuizzComponent} from './feature/quizz/list-quizz/list-quizz.component';
import {ConnectUserComponent} from './feature/user/connect-user/connect-user.component';
import {HomeComponent} from './feature/home/home.component';
import {LoginComponent} from './feature/user/login/login.component';
import {LayoutComponent} from './feature/layout/layout.component';
import {RoleGuard} from './shared/guards/role.guard';
import {User1Component} from './feature/user-1/user-1.component';
import {User2Component} from './feature/user-2/user-2.component';
import {User3Component} from './feature/user-3/user-3.component';
import {NotAuthorizedComponent} from './feature/not-authorized/not-authorized.component';
import {NotFoundComponent} from './feature/not-found/not-found.component';
import {Admin1Component} from './feature/admin-1/admin-1.component';
import {Admin2Component} from './feature/admin-2/admin-2.component';

export const routes: Routes = [
/*  { path: 'create-quizz',component:CreateQuizzComponent},
  { path: 'list-quizz',component:ListQuizzComponent},
  { path: 'connect-quizz',component:ConnectUserComponent},*/

/*  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent }*/

  {
    path: '',
    component: LoginComponent,
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'home',
        component: HomeComponent,
      },
      {
        path: 'user',
        canActivate: [RoleGuard],
        data: { roles: ['ROLES_ADMIN', 'ROLES_USER'] },
        children: [
          {path: 'user1', component: User1Component },
          {path: 'user2', component: User2Component },
          {path: 'user3', component: User3Component },
        ]
      },
      {
        path: 'admin',
        canActivate: [RoleGuard],
        data: { roles: ['ROLES_ADMIN'] },
        children: [
          {path: 'admin1', component: Admin1Component },
          {path: 'admin2', component: Admin2Component }
        ]
      }
    ]
  },
  {
    path: 'not-authorized',
    component: NotAuthorizedComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];
