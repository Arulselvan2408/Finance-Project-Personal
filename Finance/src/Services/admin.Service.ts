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
    getuserinfo(){
        return this.http.get(this.adminURL);
    }
    getactivateduserinfo(){
        return this.http.get("https://localhost:44372/api/ActiveUser/GetActivatedUserInfo");
    }
    public deluserinfo(username){
        return this.http.delete("https://localhost:44372/api/Admin?UserName="+username); 
    }
    public getuserbyusername(username){
        return this.http.get("https://localhost:44372/api/Admin?UserName="+username);
    }
    public updateuser(user:UserInformation){
        return this.http.put("https://localhost:44372/api/Admin?UserName="+user.UserName, user)
    }
    public insertuser(user){
        return this.http.post("https://localhost:44372/api/Admin", user)
    }
    public activateuser(useractivation){
        return this.http.get("https://localhost:44372/api/ActivateUser/useractivate?UserName="+useractivation);
    }
    
    
}