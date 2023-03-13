import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public eventos : any;

  ngOnInit() {
    this.getEventos();
  }

  public getEventos(){
    this.http.get('https://localhost:5001/api/Evento').subscribe(
      response => this.eventos = response,
       error => console.error(error)

    )
  }

}
