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
  constructor(private registerservice:Registerservice, private router:Router) { 
    //this.consumer= new Consumer();
  }
    
  ngOnInit(): void {
    this.getbanks();
  }

result;
onSubmit(){
  if(this.consumer.CardType==null){
    window.alert("Please Choose the Card Type");
  }
  else if(this.consumer.SelectBank==null){
    window.alert("Please Choose the Bank");
  }
  else{
  this.registerservice.Adduser(this.consumer).subscribe(
    (data)=>{this.result=data;console.log(this.result); window.alert(this.result);
      this.consumer.Password=null;
      this.consumer.ConfirmPassword=null;
  }
  );
  }
}
RedirectLogin(){
  this.router.navigate(['/Login']);
}
banks
getbanks(){
  this.registerservice.selectbank().subscribe(
    (data)=>{this.banks=data;}
  );
}
}

