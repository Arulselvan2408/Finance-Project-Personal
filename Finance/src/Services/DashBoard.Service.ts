import {HttpClient} from '@angular/common/http';
import{Injectable} from '@angular/core';
@Injectable({providedIn:"root"})
export class CardService{
    uri:string="https://localhost:44372/api/";
    constructor(private http:HttpClient)
    {

    }
    getCarddetails(username:string)
    {
        //debugger;
        return this.http.get(this.uri+"CardDashboard/CardDetails?username="+username);
       // console.log(data);
    }
    getCredit(username:string)
    {
        //debugger;
        return this.http.get(this.uri+"CardDashboard/GetCreditDetails?username="+username);
       // console.log(data);
    }
    getProductPurchase(username:string)
    {
        return this.http.get(this.uri+"CardDashboard/GetProducts?username="+username);
    }
    public getTransaction(username:string)
    {
        return this.http.get(this.uri+"CardDashboard/GetTransactions?username="+username);
    }
    public repayment(orderid:number){
        return this.http.get(this.uri+"emirepayment/EmiRepayment?orderid="+orderid);
    }
}