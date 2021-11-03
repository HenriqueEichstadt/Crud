import { Developer } from './../developer.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-developer',
  templateUrl: './view-developer.component.html',
  styleUrls: ['./view-developer.component.css']
})
export class ViewDeveloperComponent implements OnInit {

  entity: Developer = new Developer();

  constructor(private route: ActivatedRoute) {
    this.entity = this.route.snapshot.data.entity;
   }

  ngOnInit(): void {
  }

  voltar(): void {
    history.go(-1);
  }

  converterSexo(sexo: string | undefined): string{
    return Developer.converterSexo(sexo);
  }

}
