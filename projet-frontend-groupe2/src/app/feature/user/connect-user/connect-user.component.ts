import { Component } from '@angular/core';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-connect-user',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './connect-user.component.html',
  styleUrl: './connect-user.component.css'
})
export class ConnectUserComponent {
  form: FormGroup = new FormGroup({
    usernameMail: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required]),
  });

  sendData() {
    console.log(this.form.value);
  }
}
