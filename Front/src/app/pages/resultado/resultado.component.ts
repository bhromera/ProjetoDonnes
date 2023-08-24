import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from 'src/app/models/Enums';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  items: [];

  constructor(
    private apiService: ApiService,
    private router: Router
  ) { }

  async ngOnInit(): Promise<void> {
    this.items = await this.resultadoAvaliacoes();
  }

  async resultadoAvaliacoes() {

    debugger
    var response = await this.apiService.resultadoAvaliacoes();

    if (response.status != Status.OK) {
      return;
    }

    return response.value;
  }

  async novaAvaliacao()
  {
    this.router.navigate(['avaliacao']);
  }

}
