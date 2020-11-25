import { Component, OnInit } from '@angular/core';
import{Registerservice} from 'src/Services/Register.Service';
//import{Consumer} from 'src/Models/Consumer.Model';
@Component({
  selector: 'app-consumerregister',
  templateUrl: './consumerregister.component.html',
  styleUrls: ['./consumerregister.component.css']
})
export class ConsumerregisterComponent implements OnInit {
  bank:string[]=["Indian Bank","HDFC Bank","Canara Bank","State Bank of India","Punjab National Bank"]
  constructor(private registerservice:Registerservice) { }

  ngOnInit(): void {
  }
consumer:any={};
result;
onSubmit(){
  this.registerservice.Adduser(this.consumer).subscribe(
    (data)=>{this.result=data;console.log(this.result); window.alert(this.result)}
  );
}
}
