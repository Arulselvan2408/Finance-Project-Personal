import { Component, OnInit } from '@angular/core';
import {PasswordService} from 'src/Services/Password.service';
@Component({
  selector: 'app-forgetpassword',
  templateUrl: './forgetpassword.component.html',
  styleUrls: ['./forgetpassword.component.css']
})
export class ForgetpasswordComponent implements OnInit {
forgetpassword:any={}
otp:any={}
  constructor(private passwordservice:PasswordService) { }

  ngOnInit(): void {
  }
  result
  sendOTP(forgetpassword){
    debugger;
    this.passwordservice.otpgeneration(forgetpassword).subscribe(
      (data)=>{this.result=data; window.alert(this.result);}
    )
  }
}

