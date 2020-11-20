import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{HttpClientModule} from '@angular/common/http';
import{ProductService} from 'src/Services/Product.Service'
import{AdminService} from 'src/Services/admin.Service'
import{ImageUploadService} from 'src/Services/uploadImage.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductPageComponent } from './product-page/product-page.component';
import{FormsModule} from '@angular/forms';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
@NgModule({
  declarations: [
    AppComponent,
    ProductPageComponent,
    AdminpageComponent,
    ImageUploadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,FormsModule
  ],
  providers: [ProductService, AdminService, ImageUploadService],
  bootstrap: [AppComponent]
})
export class AppModule { }
