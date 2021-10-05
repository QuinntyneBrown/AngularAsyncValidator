import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { EmailExistsValidator } from './email-exists-validator';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  public emailControl = new FormControl(null, [Validators.required,Validators.email], [this._emailExistsValidator.existingEmailValidator()]);

  constructor(
    private readonly _emailExistsValidator: EmailExistsValidator
  ) {

  }
}
