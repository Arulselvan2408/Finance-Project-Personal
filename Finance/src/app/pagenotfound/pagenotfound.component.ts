import { Component, OnInit } from '@angular/core';
import { Registerservice } from  'src/Services/Register.Service';
@Component({
  selector: 'app-pagenotfound',
  templateUrl: './pagenotfound.component.html',
  styleUrls: ['./pagenotfound.component.css']
})
export class PagenotfoundComponent implements OnInit {

  constructor(private registerservice:Registerservice) { }

  ngOnInit(): void {
  }
  err;
  pagenotfound(){
    this.registerservice.Errorpage().subscribe(
      (data)=>{this.err=data;}
    )
  }

}
