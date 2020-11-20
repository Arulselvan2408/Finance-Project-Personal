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
      (data=>{this.del=data;})
    )
  }
  updateUserInfo(user:UserInformation){
    console.log();
    this.adminservice.putuser(user).subscribe(
      (data)=>{this.result=data;})
      window.alert("Record updated")
    
  }
  insertUserInfo(){
    this.adminservice.insertuser(this.userinfo).subscribe(
      (data)=>{this.result=data;}
    )
  }
}
