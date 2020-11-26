import { Component, OnInit } from '@angular/core';
import {CardService} from 'src/Services/DashBoard.Service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  carddetails:any=[];
  creditdetails:any=[];
  purchasedetails:any=[];
  transactiondetails:any=[];
  constructor(private cardservice:CardService, private router:Router) { }

  ngOnInit(): void {
    this.getCardinfo();
    this.getCreditinfo();
    this.getPurchaseinfo();
    this.getTransactioninfo();
  }
  username=sessionStorage.getItem('username');
  //calling carddetails from card service
  getCardinfo()
  {
    this.cardservice.getCarddetails(this.username).subscribe((data)=>{this.carddetails=data;console.log(this.carddetails)});
    //console.log(this.carddetails);
  }
 //calling creditdetails from card service
 getCreditinfo()
  {
    this.cardservice.getCredit(this.username).subscribe((data)=>{this.creditdetails=data;console.table(this.creditdetails)});
   
  }
  //calling purchasedetails from card service
   getPurchaseinfo()
  {
    this.cardservice.getProductPurchase(this.username).subscribe((data)=>{this.purchasedetails=data;console.log(this.purchasedetails)});
    //console.log(this.purchasedetails);

  }
  //calling transactiondetails from card service
  getTransactioninfo()
  {
    //debugger;
    this.cardservice.getTransaction(this.username).subscribe((data)=>{this.transactiondetails=data;console.table(this.transactiondetails)});
    console.log(this.transactiondetails);
  }
  payment;
  EmiRepayment(OrderID){
    this.cardservice.repayment(OrderID).subscribe(
      (data)=>{this.payment=data; window.alert(this.payment);
        this.getCardinfo();
      this.getCreditinfo();
      this.getPurchaseinfo();
      this.getTransactioninfo();
      }
    )
  }
  RedirectProduct(){
    this.router.navigate(['/ProductList'])

  }


}
