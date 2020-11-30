import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {UserInformation} from 'src/Models/Admin.Model'

@Injectable({ providedIn: "root" })
export class AdminService{
    list:UserInformation[];
    constructor(private http:HttpClient){
        this.list=[];
    }
    readonly adminURL="https://localhost:44372/api/Admin/GetUserInfo";
    readonly uri="https://localhost:44372/api/";
    getuserinfo(){
        return this.http.get(this.adminURL);
    }
    getactivateduserinfo(){
        return this.http.get(this.uri+"ActiveUser/GetActivatedUserInfo");
    }
    public deluserinfo(username){
        return this.http.delete(this.uri+"Admin?UserName="+username); 
    }
    public getuserbyusername(username){
        return this.http.get(this.uri+"Admin?UserName="+username);
    }
    public updateuser(user:UserInformation){
        return this.http.put(this.uri+"Admin?UserName="+user.UserName, user)
    }
    public insertuser(user){
        return this.http.post(this.uri+"Admin", user)
    }
    public activateuser(useractivation){
        return this.http.get(this.uri+"ActivateUser/useractivate?UserName="+useractivation);
    }
    
    
}