import {HttpClient} from '@angular/common/http';
import{Injectable} from '@angular/core';
@Injectable({providedIn:"root"})
export class CardService{
    constructor(private http:HttpClient, private http2:HttpClient)
    {

    }
    getCarddetails(username:string)
    {
        //debugger;
        return this.http.get("https://localhost:44372/api/CardDashboard/CardDetails?username="+username);
       // console.log(data);
    }
    getCredit(username:string)
    {
        //debugger;
        return this.http2.get("https://localhost:44372/api/CardDashboard/GetCreditDetails?username="+username);
       // console.log(data);
    }
    getProductPurchase(username:string)
    {
        return this.http.get("https://localhost:44372/api/CardDashboard/GetProducts?username="+username);
    }
    public getTransaction(username:string)
    {
        return this.http.get("https://localhost:44372/api/CardDashboard/GetTransactions?username="+username);
    }
    public repayment(orderid:number){
        return this.http.get("https://localhost:44372/api/emirepayment/EmiRepayment?orderid="+orderid);
    }
}