import{Injectable} from '@angular/core';
import{HttpClient} from '@angular/common/http';

@Injectable()
export class ImageUploadService{
    constructor(private http:HttpClient) {}
    postFile(ProductName:string, ProductDetails:string, fileToUpload: File, CostPerUnit:string, AvailableQuantity:string){
        const endpoint ="https://localhost:44342/api/Products";
        const formData:FormData= new FormData();
        formData.append('ProductName', ProductName);
        formData.append('ProductDetails',ProductDetails );
        formData.append('Image', fileToUpload, fileToUpload.name);
        formData.append('CostPerUnit', CostPerUnit);
        formData.append('AvailableQuantity', AvailableQuantity);
        return this.http.post(endpoint, formData);
    }
    getProducts(){
        return this.http.get("https://localhost:44342/api/Products");
    }
    getProductbyId(id){
        return this.http.get("https://localhost:44342/api/Products/"+id);
    }
    
}