import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '@/app/auth/services';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  email: string;
  password: string;

  constructor(private authService: AuthService, private router: Router)
  {
    this.email = '';
    this.password = '';
  }
  
  login() {
    this.authService.login(this.email, this.password).subscribe(result => {
      if (result) {
        this.router.navigate(['/']);
      } else {
        // handle failed login
      }
    });
  }

}
