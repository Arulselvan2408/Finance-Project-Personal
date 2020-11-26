import { HttpClient } from '@angular/common/http';

import { Injectable } from '@angular/core';
import {Consumer} from 'src/Models/Consumer.model';


@Injectable({ providedIn: "root" })
export class Registerservice{

    constructor(private http:HttpClient){

    }
    Adduser(consumertable:Consumer){
        debugger;
        return this.http.post("https://localhost:44372/api/UserRegistration/Adduser",consumertable);
    }

}