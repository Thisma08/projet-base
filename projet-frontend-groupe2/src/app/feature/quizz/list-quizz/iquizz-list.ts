export interface IquizzList {
  // id:number;
  // title: string;
  // description: string;
  // //color:string;
  // //themeId:number;
  // user_id: string;
  // theme:string
  id: number;
  title: string
  description: string
  theme: Themes
  user: Users

}

export interface Themes {
  id: number;
  title: string
}

export interface Users {
  id: number;
  username: string
  email: string
  role: string
}
