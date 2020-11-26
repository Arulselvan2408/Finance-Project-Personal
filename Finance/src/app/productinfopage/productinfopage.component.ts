import { Component, OnInit } from '@angular/core';
import{ImageUploadService} from 'src/Services/uploadImage.service';
import{NgForm} from '@angular/forms';
import { Product } from 'src/Models/Product.Model';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ProductInfoService } from 'src/Services/Productinfo.Service';

@Component({
  selector: 'app-productinfopage',
  templateUrl: './productinfopage.component.html',
  styleUrls: ['./productinfopage.component.css']
})
export class ProductinfopageComponent implements OnInit {


  constructor(private imageuploadservice:ImageUploadService, 
    private route:ActivatedRoute, private productinfoservice:ProductInfoService) {
    
   }
   
  prod:any={};
  productid;
  ngOnInit(): void {
    this.route.paramMap.subscribe((params:ParamMap)=>{
      this.productid=parseInt(params.get('id'));
    });
    this.fetchProductbyId();
  }
  fetchProductbyId(){
    this.imageuploadservice.getProductbyId(this.productid).subscribe(
      (data)=>{this.prod=data;}
    )
  }
  Username="Arulselvan";
  order
  orderProduct(productid, Quantity:HTMLInputElement, EMI:HTMLInputElement, Username)
  {
    this.productinfoservice.orderProduct(productid,parseInt(Quantity.value), parseInt(EMI.value), Username).subscribe(
      (data)=>{this.order= data; window.alert(this.order)}
    )
  }


  
  
}