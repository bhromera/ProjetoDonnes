import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Status } from 'src/app/models/Enums';
import { Router } from '@angular/router';

@Component({
  selector: 'app-avaliacao',
  templateUrl: './avaliacao.component.html',
  styleUrls: ['./avaliacao.component.css']
})
export class AvaliacaoComponent implements OnInit {

  clientes = [];
  clientesSelecionados = [];
  data: string;
  nota: number;
  motivo: string;

  erroSalvar: boolean = false;
  sucesso: boolean = false;

  constructor(private apiService: ApiService, private router: Router) { }

  async ngOnInit(): Promise<void> {
    this.clientes = await this.clientesDisponiveisAvaliacao();
  }

  async clientesDisponiveisAvaliacao() {

    debugger
    var response = await this.apiService.clientesDisponiveisAvaliacao();

    if (response.status != Status.OK) {
      return;
    }

    return response.value;
  }

  onClientesSelecionados() {
    console.log('Itens selecionados:', this.clientesSelecionados);

    this.erroSalvar = false;
    this.sucesso = false;
  }

  async salvar() {
    this.erroSalvar = false;
    this.sucesso = false;

    var data = new Date(this.data);
    var nota = this.nota;
    var motivo = this.motivo;

    this.clientesSelecionados.map(async (cliente) => {

      var avaliacao = {
        ClienteId: parseInt(cliente),
        MesAno: `${data.getMonth()}/${data.getFullYear()}`,
        Nota: nota,
        Motivo: motivo
      };

      debugger
      var response = await this.apiService.salvarAvaliacao(avaliacao);

      if (response.status != Status.OK) {
        this.erroSalvar = true;
        console.log('Erro ao salvar cliente: ', cliente);
        return;
      }

      console.log('response salvar', response);
      this.erroSalvar = false;
      this.sucesso = true;
    });
  }

  async voltar()
  {
    this.router.navigate(['resultado']);
  }

}
