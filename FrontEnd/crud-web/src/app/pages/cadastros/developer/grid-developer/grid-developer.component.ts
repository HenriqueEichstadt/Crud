import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Developer } from '../developer.model';
import { DeveloperService } from '../developer.service';

@Component({
  selector: 'app-grid-developer',
  templateUrl: './grid-developer.component.html',
  styleUrls: ['./grid-developer.component.css']
})
export class GridDeveloperComponent implements OnInit {

  developers: Developer[] = [];

  constructor(
    private developerService: DeveloperService,
    private router: Router,
    private modal: NzModalService
  ) { }

  ngOnInit(): void {
    this.ObterDevelopers();
  }

  ObterDevelopers(): void {
    this.developerService.getDevelopers()
      .subscribe((developers: Developer[]) => this.developers = developers);
  }

  editar(id: number): void {
    this.router.navigate([`./update/${id}`]);
  }

  excluir(id: number): void {
    this.developerService.deleteDeveloper(id)
      .subscribe(() => this.ObterDevelopers());
  }

  showDeleteConfirm(id: number): void {
    this.modal.confirm({
      nzTitle: 'Você tem certeza que deseja excluir o registro?',
      nzContent: '<b style="color: red;">Ao excluir não será possível desfazer</b>',
      nzOkText: 'Sim',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.excluir(id),
      nzCancelText: 'Não',
      nzOnCancel: () => console.log('Cancel')
    });
  }

  converterSexo(sexo: string | undefined): string{
    return Developer.converterSexo(sexo);
  }

}
