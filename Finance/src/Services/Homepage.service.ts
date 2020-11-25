import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: "root" })
export class HomePageService{
    constructor(private http: HttpClient) {
        
    }
getProducts(){
return this.http.get("https://localhost:44372/api/HomePage/getProduct");
    }
}