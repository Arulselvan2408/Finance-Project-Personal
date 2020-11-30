import { Component, OnInit } from '@angular/core';
import {UserInformation} from 'src/Models/Admin.Model';
import{AdminService} from 'src/Services/admin.Service';
import{NgForm} from '@angular/forms';


@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.css']
})
export class AdminpageComponent implements OnInit {
  userinfo:UserInformation;
  constructor(private adminservice:AdminService) {
    this.userinfo= new UserInformation();
   }

  ngOnInit(): void {
    this.fetchuserinfo();
    
  }
  userinformation;
  fetchuserinfo(){
    this.adminservice.getuserinfo().subscribe(
      (data)=>{this.userinformation=data});
  }

  result;

  del;
  removeuserinfo(username){
    this.adminservice.deluserinfo(username).subscribe(
      (data=>{this.del=data; window.alert(this.del); this.fetchuserinfo();})
    )
    
  }
  updateUserInfo(useredit:UserInformation){
    
    this.adminservice.updateuser(useredit).subscribe(
      (data)=>{this.result=data;this.fetchuserinfo();window.alert(this.result)}
      )
    
  }
  useredit:any={}
  insertUserInfo(){
    this.adminservice.insertuser(this.userinfo).subscribe(
      (data)=>{this.useredit=data;}
    )
  }
  

  fetchuserbyName(username){
    this.adminservice.getuserbyusername(username).subscribe(
      (data)=>{this.useredit=data; console.log(this.useredit)}
    )
  }
  activation;
  activateuser(useractivation){
    this.adminservice.activateuser(useractivation).subscribe(
      (data)=>{this.activation=data; window.alert(this.activation);this.fetchuserinfo();}
    )
  }
}
