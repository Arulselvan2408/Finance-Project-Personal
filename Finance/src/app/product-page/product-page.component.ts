import { Component, OnInit } from '@angular/core';
import {Product} from 'src/Models/Product.Model';
import {ProductService} from 'src/Services/Product.Service';

import {NgForm} from '@angular/forms';


@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {
 product:Product;

  constructor(private prdservice:ProductService) {
    this.product= new Product();
   }

  ngOnInit(): void {
    this.fetchProduct();
  }
  Products;
  fetchProduct(){
    this.prdservice.getProducts().subscribe((data)=>{
      this.Products=data;    
    })
  }
 
 
}
