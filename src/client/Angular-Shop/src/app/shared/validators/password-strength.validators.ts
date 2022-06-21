import { AbstractControl, ValidationErrors } from '@angular/forms';

export const PasswordStrengthValidator = function (
  control: AbstractControl,
): ValidationErrors | null {
  let value: string = control.value || '';
  if (!value) {
    return null;
  }

  const upperCaseCharacters = /[A-Z]+/g;
  const numberCharacters = /[0-9]+/g;
  const specialCharacters = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;
  let isPasswordValid =
    upperCaseCharacters.test(value) &&
    numberCharacters.test(value) &&
    specialCharacters.test(value);
  if (!isPasswordValid) {
    return {
      passwordStrength: 'Password must contain numbers, uppercase letters, or special characters.',
    };
  }
  return null;
};
