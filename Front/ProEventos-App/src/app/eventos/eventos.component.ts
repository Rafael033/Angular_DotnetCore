import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public eventos : any = [];
  widthImg : number = 100;
  heightImg: number = 50;
  showImg : boolean = true;
  searchBtn: boolean =false;

  //private _filterSeach : string;

  ngOnInit() {
    this.getEventos();
  }

  dynamicImg(){
    this.showImg = !this.showImg;
  }

  public getEventos(){
    this.http.get('https://localhost:5001/api/Evento').subscribe(
      response => this.eventos = response,
       error => console.error(error)

    )
  }

}
