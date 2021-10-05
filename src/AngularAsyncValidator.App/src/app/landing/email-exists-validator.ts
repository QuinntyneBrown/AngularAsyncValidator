import { Injectable } from "@angular/core";
import { AbstractControl, AsyncValidatorFn } from "@angular/forms";
import { ProfileService } from "@api";
import { Observable, of } from "rxjs";
import { map, debounceTime, take, switchMap } from "rxjs/operators";

function isEmptyInputValue(value: any): boolean {
  return value === null || value.length === 0;
}

@Injectable({
  providedIn: "root"
})
export class EmailExistsValidator {
  constructor(
    private readonly _profileService: ProfileService) {}

  existingEmailValidator(initialEmail: string = ""): AsyncValidatorFn {
    return (
      control: AbstractControl
    ):
      | Promise<{ [key: string]: any } | null>
      | Observable<{ [key: string]: any } | null> => {
      if (isEmptyInputValue(control.value)) {
        return of(null);
      } else if (control.value === initialEmail) {
        return of(null);
      } else {
        return control.valueChanges.pipe(
          debounceTime(500),
          take(1),
          switchMap(_ =>
            this._profileService
              .emailExists(control.value)
              .pipe(
                map(dto =>
                  dto.exists ? { existingEmail: { value: control.value } } : null
                )
              )
          )
        );
      }
    };
  }
}
