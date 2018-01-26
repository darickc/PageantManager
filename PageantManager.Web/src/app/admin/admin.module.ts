import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { AdminComponent } from './admin.component';
import { PageantsComponent } from './pageants/pageants.component';
import { CostumesComponent } from './costumes/costumes.component';
import { CostumeComponent } from './costume/costume.component';
import { GarmentTypesComponent } from './garment-types/garment-types.component';
import { GarmentTypeComponent } from './garment-type/garment-type.component';
import { GarmentsComponent } from './garments/garments.component';
import { GarmentComponent } from './garment/garment.component';

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
      },
      {
        path: 'costumes',
        component: CostumesComponent,
        data: { title: 'Costumes' }
      },
      {
        path: 'costumes/:id',
        component: CostumeComponent,
        data: { title: 'Costume' }
      },
      {
        path: 'garment-types',
        component: GarmentTypesComponent,
        data: { title: 'Garment Types' }
      },
      {
        path: 'garment-types/:id',
        component: GarmentTypeComponent,
        data: { title: 'Garment Type' }
      },
      {
        path: 'garment-types/:id/garments',
        component: GarmentsComponent,
        data: { title: 'Garments' }
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    SharedModule,
  ],
  declarations: [
    AdminComponent,
    PageantsComponent,
    CostumesComponent,
    CostumeComponent,
    GarmentTypesComponent,
    GarmentTypeComponent,
    GarmentsComponent,
    GarmentComponent],
  exports: [RouterModule]
})
export class AdminModule { }
