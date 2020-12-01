import {HttpClient} from '@angular/common/http';
import{Injectable} from '@angular/core';
import { Router } from '@angular/router';




@Injectable({providedIn:"root"})
export class PasswordService{
    constructor(private http: HttpClient) {
        
    }
    message
    otpgeneration(phone){
        return this.http.get("https://localhost:44322/api/OTP?phone="+phone);
    }
}