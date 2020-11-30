import { HttpClient } from '@angular/common/http';

import { Injectable } from '@angular/core';
import {Consumer} from 'src/Models/Consumer.model';


@Injectable({ providedIn: "root" })
export class Registerservice{
    readonly uri="https://localhost:44372/api/";
    constructor(private http:HttpClient){

    }
    Adduser(consumertable:Consumer){
        debugger;
        return this.http.post(this.uri+"UserRegistration/Adduser",consumertable);
    }
    Errorpage(){
        return this.http.get(this.uri+"Pagenotfound/ErrorPage");
    }
    selectbank(){
        return this.http.get(this.uri+"UserRegistration/getbanks");
    }

}