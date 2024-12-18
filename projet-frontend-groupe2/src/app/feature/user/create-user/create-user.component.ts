import { Component } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent {
  form: FormGroup = new FormGroup({
    username: new FormControl("", [Validators.required]),
    mail: new FormControl("", [Validators.pattern(/^[\w.]+@[\w-]+.+[\w-]{2,4}$/), Validators.required]),
    password: new FormControl("", [Validators.required, Validators.minLength(6)]),
  });


  sendData() {
    console.log(this.form.value);
  }
}
