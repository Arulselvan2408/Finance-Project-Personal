import { Component, OnInit } from '@angular/core';
import{Registerservice} from 'src/Services/Register.Service';
import{Consumer} from 'src/Models/Consumer.Model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-consumerregister',
  templateUrl: './consumerregister.component.html',
  styleUrls: ['./consumerregister.component.css']
})
export class ConsumerregisterComponent implements OnInit {
  //consumer:Consumer;
  consumer:Consumer={};
  bank:string[]=["Indian Bank","HDFC Bank","Canara Bank","State Bank of India","Punjab National Bank"]
  constructor(private registerservice:Registerservice, private router:Router) { 
    //this.consumer= new Consumer();
  }
    
  ngOnInit(): void {
    
  }

result;
onSubmit(){
  this.registerservice.Adduser(this.consumer).subscribe(
    (data)=>{this.result=data;console.log(this.result); window.alert(this.result)}
  );
}
RedirectLogin(){
  this.router.navigate(['/Login']);
}
}

