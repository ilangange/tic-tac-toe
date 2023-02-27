import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) {

    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  login(): void {
    if (this.form.valid) {
      const val = this.form.value;

      this.authService.login(val.username, val.password)
        .subscribe(
          (res: any) => {
            if (res !== null) {
              this.authService.saveToken(res.data);
              this.router.navigateByUrl('/game');
            }
          }
        );
    }
  }
}
