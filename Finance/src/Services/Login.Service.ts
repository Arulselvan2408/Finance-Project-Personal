import {HttpClient} from '@angular/common/http';
import{Injectable} from '@angular/core';
import { Router } from '@angular/router';




@Injectable({providedIn:"root"})
export class LoginService
{
    constructor(private http:HttpClient, private router:Router){

    }
    loginsessionvariable;
    loginuser;
    loginCheck()
    {
        this.loginuser= sessionStorage.getItem('username');
        if(this.loginuser !="")
        {
            this.loginsessionvariable= true;
        }
        else
        {
            this.loginsessionvariable=false;
        }
    }
    
    userlogin(user:any)
    {
        return this.http.post("https://localhost:44372/api/Login",user);
    }
    public loginuservariable:boolean;
    publicdolofoff()
    {
        sessionStorage.clear();
        this.loginsessionvariable=false;
        this.router.navigate(['/Home']);
    }

}