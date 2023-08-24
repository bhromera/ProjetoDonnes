import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { AvaliacaoComponent } from './pages/avaliacao/avaliacao.component';
import { ResultadoComponent } from './pages/resultado/resultado.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AvaliacaoComponent,
    ResultadoComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
