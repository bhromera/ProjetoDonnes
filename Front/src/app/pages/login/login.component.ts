import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { Status } from 'src/app/models/Enums';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string;
  senha: string;
  erroLogin: boolean = false;

  constructor(
    private loginService: ApiService,
    private router: Router,
    private storage: StorageService,) { }

  ngOnInit(): void {
  }

  async login() {
    this.erroLogin = false;
    debugger
    var efetuarLogin = await this.loginService.login(this.email, this.senha);

    if (efetuarLogin.status != Status.OK) {
      this.erroLogin = true;
      return;
    }

    this.storage.set('login', efetuarLogin.value);
    await this.storage.set('email', this.email);
    await this.storage.set('senha', this.senha);

    console.log('storage ', this.storage.get('login'));

    this.router.navigate(['resultado']);
  }
}
