import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'VantageTag.TicTacToe.Web';
  isLoggedIn: boolean = false;

  constructor(
    private router: Router, private authService: AuthService
  ) { }
  
  ngOnInit(): void {
    this.authService.checkLogin().subscribe(res => {
      if (res != null) {
        this.isLoggedIn = res;
      }
    });
  }
}
