import { Component, OnInit } from '@angular/core';
import {Product} from 'src/Models/Product.Model';
import{HomePageService} from 'src/Services/Homepage.service';
@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.css']
})
export class HomeComponentComponent implements OnInit {

 product:Product;
  constructor(private homepageservice:HomePageService) { 
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
}
