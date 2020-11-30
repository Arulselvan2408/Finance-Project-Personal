import { ReadVarExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import {Product} from 'src/Models/Product.Model';
import{ImageUploadService} from 'src/Services/uploadImage.service';
import{ProductInfoService} from 'src/Services/Productinfo.Service';
import { Orderinfo } from 'src/Models/orderinfo.model';
@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent implements OnInit {
 
  Products;
product:Product;
  constructor(private imageuploadservice:ImageUploadService, private productinfoservice:ProductInfoService) {
    this.product= new Product();
   }

  ngOnInit(): void {
    this.fetchProduct();
  }

  fetchProduct(){
    this.imageuploadservice.getProducts().subscribe((data)=>{
      this.Products=data;    
    })
  }
  Pro:Product;
  fetchProductbyID(id){
    this.imageuploadservice.getProductbyId(id).subscribe(
      (data)=>{this.Pro=data;
        /*let orderinfo=new Product();
        orderinfo.ProductID=this.Pro.ProductID;
        orderinfo.ProductName= this.Pro.ProductName;
        orderinfo.Image= this.Pro.Image;
        orderinfo.ProductDetails= this.Pro.ProductDetails;
        orderinfo.AvailableQuantity= 1;
      this.productinfoservice.getProductbyId(orderinfo.ProductID);*/
      }
      )
      
  }
  

}
