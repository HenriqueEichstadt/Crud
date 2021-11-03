import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeveloperService } from './developer.service';
import { GridDeveloperComponent } from './grid-developer/grid-developer.component';
import { InsertDeveloperComponent } from './insert-developer/insert-developer.component';
import { UpdateDeveloperComponent } from './update-developer/update-developer.component';
import { ViewDeveloperComponent } from './view-developer/view-developer.component';

const routes: Routes = [
  {
    path: '',
    component: GridDeveloperComponent
  },
  {
    path: 'insert',
    component: InsertDeveloperComponent
  },
  {
    path: 'update/:id',
    resolve: {
      entity: DeveloperService
    },
    component: UpdateDeveloperComponent
  },
  {
    path: 'view/:id',
    resolve: {
      entity: DeveloperService
    },
    component: ViewDeveloperComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DeveloperRoutingModule { }
