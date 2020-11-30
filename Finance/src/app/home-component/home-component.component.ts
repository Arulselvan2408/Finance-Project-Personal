import { Component, OnInit } from '@angular/core';
import {Product} from 'src/Models/Product.Model';
import{HomePageService} from 'src/Services/Homepage.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.css']
})
export class HomeComponentComponent implements OnInit {

 product:Product;
  constructor(private homepageservice:HomePageService, private router:Router) { 
    this.product= new Product();
  }
 
  ngOnInit(): void {
    this.getproduct();
  }
  prod;
getproduct(){
  this.homepageservice.getProducts().subscribe(
    (data)=>{this.prod=data}
  )
}
RedirectLogin(productid:number){
  if(sessionStorage.getItem('username'))
  {
    this.router.navigate(['ProductInfo/',productid ]);
  }
  else{
    this.router.navigate(['/Login']);
  }
  
}
}
