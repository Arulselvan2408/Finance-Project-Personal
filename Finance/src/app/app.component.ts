import { Component } from '@angular/core';
import { DomSanitizer, SafeResourceUrl, SafeUrl } from '@angular/platform-browser';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Finance';
  constructor(private sanitizer: DomSanitizer) {}
public getSantizeUrl(url:any) {
    return this.sanitizer.bypassSecurityTrustUrl(url);
}
}
