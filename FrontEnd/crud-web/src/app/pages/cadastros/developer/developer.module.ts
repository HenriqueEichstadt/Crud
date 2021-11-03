import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/shared.module';
import { MensagemModule } from 'src/app/componentes/mensagem/mensagem.module';
import { DeveloperRoutingModule } from './developer-routing.module';
import { DeveloperService } from './developer.service';
import { GridDeveloperComponent } from './grid-developer/grid-developer.component';
import { ViewDeveloperComponent } from './view-developer/view-developer.component';
import { InsertDeveloperComponent } from './insert-developer/insert-developer.component';
import { UpdateDeveloperComponent } from './update-developer/update-developer.component';


@NgModule({
  imports: [
    SharedModule,
    CommonModule,
    DeveloperRoutingModule,
    MensagemModule
  ],
  declarations: [
    GridDeveloperComponent,
    ViewDeveloperComponent,
    InsertDeveloperComponent,
    UpdateDeveloperComponent
  ],
  exports: [
    GridDeveloperComponent,
    ViewDeveloperComponent,
    InsertDeveloperComponent,
    UpdateDeveloperComponent
  ],
  providers: [
    DeveloperService,
  ]
})
export class DeveloperModule { }
