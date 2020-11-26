import { Directive, Input } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator } from '@angular/forms';

@Directive({
  selector: '[passwordmatchvalidator]',
  providers:[{
    provide: NG_VALIDATORS, 
    useExisting:PasswordMatchDirective,
    multi:true

  }] 
})
export class PasswordMatchDirective implements Validator{
    @Input() passwordmatchvalidator:string
    validate(control:AbstractControl):{[key:string]:any} |null{
        const controlToCompare=control.parent.get(this.passwordmatchvalidator);
        if(controlToCompare&&controlToCompare.value !==control.value){
            return{'notEqual':true};
        }
        return null;
    }

}