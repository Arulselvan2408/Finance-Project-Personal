import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{HttpClientModule} from '@angular/common/http';
import{ProductService} from 'src/Services/Product.Service'
import{AdminService} from 'src/Services/admin.Service'
import{ImageUploadService} from 'src/Services/uploadImage.service';
import{Registerservice} from 'src/Services/Register.Service';
import{PasswordMatchDirective} from 'src/app/PasswordMatching/passwordmatch.directive';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductPageComponent } from './product-page/product-page.component';
import{FormsModule} from '@angular/forms';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { ProductinfopageComponent } from './productinfopage/productinfopage.component';
import { ProductInfoService } from 'src/Services/Productinfo.Service';
import { ConsumerregisterComponent } from './consumerregister/consumerregister.component';
import { LoginpageComponent } from './loginpage/loginpage.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import {CardService} from 'src/Services/DashBoard.Service';
import { AdminlayoutComponent } from './adminlayout/adminlayout.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { ForgetpasswordComponent } from './forgetpassword/forgetpassword.component';
import { ActiveuserComponent } from './activeuser/activeuser.component'
import {PasswordService} from 'src/Services/Password.service';
@NgModule({
  declarations: [
    AppComponent,
    ProductPageComponent,
    AdminpageComponent,
    ImageUploadComponent,
    HomeComponentComponent,
    ProductinfopageComponent,
    ConsumerregisterComponent,
    PasswordMatchDirective,
    LoginpageComponent,
    DashboardComponent,
    AdminlayoutComponent,
    PagenotfoundComponent,
    ForgetpasswordComponent,
    ActiveuserComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,FormsModule
  ],
  providers: [ProductService, AdminService, ImageUploadService, ProductInfoService, Registerservice,CardService, PasswordService],
  bootstrap: [AppComponent]
})
export class AppModule { }
