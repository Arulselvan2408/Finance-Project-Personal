import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Product} from 'src/Models/Product.Model'
@Injectable({ providedIn: "root" })
export class ProductService{
    
    constructor(private http: HttpClient) {
        
    }
readonly producturl="https://localhost:44342/api/Products";
getProducts(){
    return this.http.get(this.producturl);
}
public getProductbyid(id)
{
    return this.http.get(this.producturl+id);
}
public postproduct(product){
    return this.http.post(this.producturl,product);
}


}
