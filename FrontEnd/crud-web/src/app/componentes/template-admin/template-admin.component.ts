import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-template-admin',
  templateUrl: './template-admin.component.html',
  styleUrls: ['./template-admin.component.css']
})
export class TemplateAdminComponent implements OnInit {

  isCollapsed = false;
  mostrarMenu: boolean = true;

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

}
