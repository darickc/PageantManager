import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { AdminComponent } from './admin.component';
import { PageantsComponent } from './pageants/pageants.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: AdminComponent,
        data: { title: 'Admin' }
      },
      {
        path: 'pageants',
        component: PageantsComponent,
        data: { title: 'Pageants' }
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    SharedModule,
  ],
  declarations: [AdminComponent, PageantsComponent],
  exports: [RouterModule]
})
export class AdminModule { }
