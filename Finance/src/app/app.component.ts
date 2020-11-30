import { Component } from '@angular/core';
import { Router} from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Finance';
  loginsession;
  username;
  constructor(private router:Router) {}
ngDoCheck()
{
  if(sessionStorage.getItem('username')){
    this.loginsession= true;
    this.username=sessionStorage.getItem('username');
  }
  else{
    this.loginsession=false;
  }
}
logOff(){
  sessionStorage.clear();
  this.loginsession=false;
  this.router.navigate(['Home']);
}
RedirectDashboard(){
  this.router.navigate(['/DashBoard']);
}
}
