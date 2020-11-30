import { Component, OnInit } from '@angular/core';
import{AdminService} from 'src/Services/admin.Service';
import {UserInformation} from 'src/Models/Admin.Model';

@Component({
  selector: 'app-activeuser',
  templateUrl: './activeuser.component.html',
  styleUrls: ['./activeuser.component.css']
})
export class ActiveuserComponent implements OnInit {
userinfo:UserInformation;
  constructor(private adminservice:AdminService) { }

  ngOnInit(): void {
    this.fetchactivateduserinfo();
  }
  activateduserinfo;
  fetchactivateduserinfo(){
    this.adminservice.getactivateduserinfo().subscribe(
      (data)=>{this.activateduserinfo=data;}
    );
  }

  useredit:any={}
  insertUserInfo(){
    this.adminservice.insertuser(this.userinfo).subscribe(
      (data)=>{this.useredit=data;}
    )
  }
  result;
  updateUserInfo(useredit:UserInformation){
    
    this.adminservice.updateuser(useredit).subscribe(
      (data)=>{this.result=data;this.fetchactivateduserinfo();window.alert(this.result)}
      )
    
  }

  fetchuserbyName(username){
    this.adminservice.getuserbyusername(username).subscribe(
      (data)=>{this.useredit=data; console.log(this.useredit)}
    )
  }
}
