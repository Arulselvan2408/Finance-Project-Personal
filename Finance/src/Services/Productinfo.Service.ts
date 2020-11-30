import{Injectable} from '@angular/core';
import{HttpClient} from '@angular/common/http';

@Injectable()
export class ProductInfoService{
    readonly uri="https://localhost:44372/api/"
    constructor(private http:HttpClient) {}
    getProductbyId(id){
        debugger;
        return this.http.get(this.uri+"ProductInfo/id");
    }
    orderProduct(productid:number,quantity:number, EMI:number,username:string){
        return this.http.get(this.uri+"ProductInfo?productid="+productid+"&quantity="+quantity+"&EMI="+EMI+"&Username="+username);
    }
}