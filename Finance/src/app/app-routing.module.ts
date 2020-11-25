import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminService } from 'src/Services/admin.Service';
import { HomePageService } from 'src/Services/Homepage.service';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { ProductinfopageComponent } from './productinfopage/productinfopage.component';

const routes: Routes = [
  {path: 'ProductList', component: ImageUploadComponent},
  {path: 'Admin', component:AdminpageComponent},
  {path:'Home', component:HomeComponentComponent},
  {path:'', redirectTo:'/Home', pathMatch:'full'},
  {path:'ProductInfo/:id',component:ProductinfopageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
