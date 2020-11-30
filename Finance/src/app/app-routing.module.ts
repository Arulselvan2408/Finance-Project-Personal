import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminService } from 'src/Services/admin.Service';
import { HomePageService } from 'src/Services/Homepage.service';
import { ActiveuserComponent } from './activeuser/activeuser.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { ConsumerregisterComponent } from './consumerregister/consumerregister.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { LoginpageComponent } from './loginpage/loginpage.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { ProductinfopageComponent } from './productinfopage/productinfopage.component';

const routes: Routes = [
  {path: 'ProductList', component: ImageUploadComponent},
  {path:'adminlayout', component:AdminpageComponent},
  {path: 'Admin',component:AdminpageComponent},
  {path:'Home', component:HomeComponentComponent},
  {path:'', redirectTo:'/Home', pathMatch:'full'},
  {path:'Register',component:ConsumerregisterComponent},
  {path:'ProductInfo/:id',component:ProductinfopageComponent},
  {path:'Login',component:LoginpageComponent},
  {path:'DashBoard', component:DashboardComponent},
  {path:'ActiveUser', component:ActiveuserComponent},
  {path:'**', component:PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
