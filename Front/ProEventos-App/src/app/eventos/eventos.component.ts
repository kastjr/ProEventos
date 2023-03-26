import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventosFiltrados: any = [];
  public eventos : any = [];
  larguraimg: number=150;
  margemimg: number=2;
  mostrarimg: boolean=true;
  private _filtrolista: string = '';

  public get filtrolista(): string {
    return this._filtrolista;
  }

  public set filtrolista(value: string) {
    this._filtrolista=value;
    this.eventosFiltrados = this.filtrolista ? this.filtrarEventos(this.filtrolista) : this.eventos
  }

  filtrarEventos (filtrarPor: string) : any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  alterarImg(){
    this.mostrarimg = !this.mostrarimg
  }

  public getEventos(): void {
    this.http.get("https://localhost:5001/api/Eventos").subscribe(
      response => {this.eventos = response;
                   this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );


    this.eventos = [
      {
        Tema: 'Angular 11',
        Local: 'Teresina'
      },
      {
        Tema: '.NEt 5',
        Local: 'Teresina'
      },
      {
        Tema: 'Angular e suas novidades',
        Local: 'Teresina'
      }
    ];
  }

}
