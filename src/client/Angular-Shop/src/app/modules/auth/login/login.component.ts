import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../../core/service/authentication.service';
import { PasswordStrengthValidator } from 'src/app/shared/validators/password-strength.validators';
import { UserPageActions } from 'src/app/core/store/actions';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { State } from '../state/app.state';
import { getMaskUserName } from 'src/app/core/store/selectors/user.selector';

@Component({ 
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  loading = false;

  submitted = false;

  returnUrl!: string;
  error = '';

  maskUserName$: Observable<boolean>;

  constructor(
    private store: Store<State>,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.userValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.maskUserName$ = this.store.select(getMaskUserName);
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(8),
          PasswordStrengthValidator,
        ]),
      ],
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get formControl() {
    return this.loginForm.controls;
  }

  checkChanged(): void {
    this.store.dispatch(UserPageActions.maskUserName());
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService
      .login(this.formControl['username'].value, this.formControl['password'].value)
      .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate([this.returnUrl]);
        },
        (err) => {
          this.error = 'Incorrect username or password!!!';
          this.loading = false;
        },
      );
  }
}
