import{Injectable} from '@angular/core';
import{HttpClient} from '@angular/common/http';

@Injectable()
export class ProductInfoService{
    constructor(private http:HttpClient) {}
    getProductbyId(id){
        debugger;
        return this.http.get("https://localhost:44372/api/ProductInfo/id");
    }
    orderProduct(productid:number,quantity:number, EMI:number,username:string){
        return this.http.get("https://localhost:44372/api/ProductInfo?productid="+productid+"&quantity="+quantity+"&EMI="+EMI+"&Username="+username);
    }
}