import { Component, OnInit } from '@angular/core';
import{ImageUploadService} from 'src/Services/uploadImage.service';
import{NgForm} from '@angular/forms';
import { Product } from 'src/Models/Product.Model';
import { ActivatedRoute, ParamMap } from '@angular/router';
import{Router} from '@angular/router';
import { ProductInfoService } from 'src/Services/Productinfo.Service';

@Component({
  selector: 'app-productinfopage',
  templateUrl: './productinfopage.component.html',
  styleUrls: ['./productinfopage.component.css']
})
export class ProductinfopageComponent implements OnInit {
  quan:[1,2,3,4,5];

  constructor(private imageuploadservice:ImageUploadService, 
    private route:ActivatedRoute, private productinfoservice:ProductInfoService, private router:Router) {
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
  Username=sessionStorage.getItem('username');
  order
  orderProduct(productid, Quantity:HTMLInputElement, EMI:HTMLInputElement, Username)
  {
    this.productinfoservice.orderProduct(productid,parseInt(Quantity.value), parseInt(EMI.value), Username).subscribe(
      (data)=>{this.order= data; window.alert(this.order); this.router.navigate(['/DashBoard'])}
    )
  }


  
  
}
