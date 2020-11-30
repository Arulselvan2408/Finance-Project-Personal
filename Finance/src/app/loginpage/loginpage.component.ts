import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Consumer } from 'src/Models/Consumer.Model';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/Services/Login.Service';
@Component({
  selector: 'app-loginpage',
  templateUrl: './loginpage.component.html',
  styleUrls: ['./loginpage.component.css']
})
export class LoginpageComponent implements OnInit {

  constructor(private loginservice: LoginService, private router: Router) { }
  consumer:any = {};
  loggedinempdetails;
  err;
  ngOnInit(): void {
  }
  doLogin() {
    if (this.consumer.UserName=="Rajiv" && this.consumer.Password=="admin@123") {
      debugger;
      this.loginservice.loginsessionvariable = true;
      sessionStorage.setItem('username', 'Rajiv');
      this.loginservice.loginCheck();
      this.router.navigate(['/Admin']);
    }
    else if (this.consumer != null) {
      this.loginservice.userlogin(this.consumer).subscribe(
        (data) => {
          this.loggedinempdetails = data as string;
          sessionStorage.setItem('username', this.loggedinempdetails);
          this.loginservice.loginCheck();
          if (data != 'Invalid' && data !='Not Activated by Admin') {
            this.loginservice.loginuservariable = true;
            this.router.navigate(['/DashBoard']);
          }
          else if (data !='Not Activated by Admin'){
            this.err = "Invalid Username & Password";
            sessionStorage.clear();
            window.alert(this.err);
            this.router.navigate(['/Login']);
          }
          else{
            this.err = "You Verification is under Process or Activation by Admin is Pending";
            sessionStorage.clear();
            window.alert(this.err);
            this.router.navigate(['/Login']);
          }
        });
    }
    else{
      this.err="Please enter Valid Credentials !!!";
    }
  }
  redirectlogin(){
    this.router.navigate(['/Register']);
  }
}

