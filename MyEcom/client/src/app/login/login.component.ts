import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, AfterViewInit {

  @ViewChild('username') username: MatInput ;

  constructor() { }

  ngAfterViewInit(): void {
  this.username.focus();
  }

  ngOnInit(): void {
  }

  submit(f: NgForm): void{
    console.log(f.control.get('username').value);
    console.log(f.control.get('password').value);
    console.log(f.control.get('checkbox').value);
    console.log(f.control.get('birthday').value);
  }

}
