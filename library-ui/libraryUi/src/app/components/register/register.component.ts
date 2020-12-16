import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  public loginInvalid: boolean;
  public loading: boolean;
  public error: string;

  private formSubmitAttempt: boolean;
  private returnUrl: string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService
  ) {
  }

  async ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    this.form = this.fb.group({
      name: ['', Validators.required],
      direction: ['', Validators.required],
      phone: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    });

    if (await this.authService.currentUserValue) {
      await this.router.navigate([this.returnUrl]);
    }
  }

  async onSubmit() {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      const name = this.form.get('name').value;
      const direction = this.form.get('direction').value;
      const phone = this.form.get('phone').value;
      const password = this.form.get('password').value;
      const confirmPassword = this.form.get('confirmPassword').value;

      this.authService.register(name,direction,phone, password,confirmPassword)
        .subscribe(
          data => {
            this.router.navigate([this.returnUrl]);
          },
          error => {
            this.loading = false;
            this.loginInvalid = true;
            this.error = error;
          });

    } else {
      this.formSubmitAttempt = true;
    }
  }
}
