import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Result } from '../models/Result';
import { Status } from '../models/Enums';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:5001';

  constructor(private http: HttpClient, private storage: StorageService) {}

  async login(email: string, senha: string): Promise<Result<any>> {
    let result = {} as Result<any>;

    const body = { email, senha };
    await this.http.post(`${this.apiUrl}/v1/login`, body)
    .toPromise()
    .then((res) => {
          console.log(res);
          result.status = Status.OK;
          result.value = res;
        })
        .catch((err) => {
          result.status = err.status;
          result.message = err.message;
          result.value = {};
          console.log(err);
        })
        .finally(() => console.log('Final Login'));

    return result;
  }

  async resultadoAvaliacoes(): Promise<Result<any>> {
    let result = {} as Result<any>;

    let header = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8;',  'Authorization': `bearer ${this.storage.get('login')?.token}` })

    await this.http.get(`${this.apiUrl}/v1/Avaliacao/GetResult`, { headers: header })
    .toPromise()
    .then((res) => {
          console.log(res);
          result.status = Status.OK;
          result.value = res;
        })
        .catch((err) => {
          result.status = err.status;
          result.message = err.message;
          result.value = {};
          console.log(err);
        })
        .finally(() => console.log(''));

    return result;
  }

  async clientesDisponiveisAvaliacao(): Promise<Result<any>> {
    let result = {} as Result<any>;

    let header = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8;',  'Authorization': `bearer ${this.storage.get('login')?.token}` })

    await this.http.get(`${this.apiUrl}/v1/Cliente/GetEnabledToAvaliation`, { headers: header })
    .toPromise()
    .then((res) => {
          console.log(res);
          result.status = Status.OK;
          result.value = res;
        })
        .catch((err) => {
          result.status = err.status;
          result.message = err.message;
          result.value = {};
          console.log(err);
        })
        .finally(() => console.log(''));

    return result;
  }

  async salvarAvaliacao(avaliacao): Promise<Result<any>> {
    let result = {} as Result<any>;

    let header = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8;',  'Authorization': `bearer ${this.storage.get('login')?.token}` })

    await this.http.post(`${this.apiUrl}/v1/avaliacao`, avaliacao, { headers: header })
    .toPromise()
    .then((res) => {
          console.log(res);
          result.status = Status.OK;
          result.value = res;
        })
        .catch((err) => {
          result.status = err.status;
          result.message = err.message;
          result.value = {};
          console.log(err);
        })
        .finally(() => console.log(''));

    return result;
  }

}
