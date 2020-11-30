import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adminlayout',
  templateUrl: './adminlayout.component.html',
  styleUrls: ['./adminlayout.component.css']
})
export class AdminlayoutComponent implements OnInit {
  loginsession;
  username;
  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  ngDoCheck()
{
  if(sessionStorage.getItem('username')){
    this.loginsession= true;
    this.username=sessionStorage.getItem('username');
  }
  else{
    this.loginsession=false;
  }
}
logOff(){
  sessionStorage.clear();
  this.loginsession=false;
  this.router.navigate(['Home']);
}
}
