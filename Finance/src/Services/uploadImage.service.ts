import{Injectable} from '@angular/core';
import{HttpClient} from '@angular/common/http';
import{Product} from 'src/Models/Product.Model';
import { from } from 'rxjs';

@Injectable()
export class ImageUploadService{
    product:Product[];
    orderinfopage:Product[];
    constructor(private http:HttpClient) {
        this.orderinfopage=[];
    }
   
    getProducts(){
        return this.http.get("https://localhost:44372/api/Products");
    }
    public getProductbyId(id){
        debugger;
        return this.http.get("https://localhost:44372/api/ProductInfo/"+id);
    }
    

    
}