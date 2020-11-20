import { ReadVarExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import {Product} from 'src/Models/Product.Model';
import{ImageUploadService} from 'src/Services/uploadImage.service';
@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent implements OnInit {
  imageUrl:string= "/assets/img/default.png";
  Products;
  fileToUpload: File= null;
product:Product;
  constructor(private imageuploadservice:ImageUploadService) {
    this.product= new Product();
   }

  ngOnInit(): void {
    this.fetchProduct();
  }
  handleFileInput(file:FileList){
    this.fileToUpload= file.item(0);
    var reader= new FileReader();
    reader.onload=(event:any)=>{
      this.imageUrl= event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }
  OnSubmit(ProductName,ProductDetails, Image,CostPerUnit, AvailableQuantity){
    this.imageuploadservice.postFile(ProductName.value,ProductDetails.value, this.fileToUpload,CostPerUnit.value, AvailableQuantity.value).subscribe(
      data=>{console.log('done');
      ProductName.value=null;
      ProductDetails.value=null;
      this.fileToUpload=null;
      CostPerUnit.value=null;
      AvailableQuantity.value=null;
      window.alert("Product Added");
    }
    ) 
  }
  fetchProduct(){
    this.imageuploadservice.getProducts().subscribe((data)=>{
      this.Products=data;    
    })
  }
  prod:any={};
  fetchProductbyID(id){
    this.imageuploadservice.getProductbyId(id).subscribe(
      (data)=>{this.prod=data;}
    )
  }

}
