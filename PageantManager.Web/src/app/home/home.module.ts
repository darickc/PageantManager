import { NgModule, ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home.component';

const homeRouting: ModuleWithProviders = RouterModule.forChild([
  {
    path: '',
    children: [
      {
        path: '',
        component: HomeComponent,
        data: { title: 'Pageant Manager' }
      }
    ]
  }
]);

@NgModule({
  imports: [
    SharedModule,
    homeRouting
  ],
  declarations: [
    HomeComponent
  ]
})
export class HomeModule { }
