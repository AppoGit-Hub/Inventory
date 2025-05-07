import {
  booleanAttribute,
  Directive,
  effect,
  inject,
  input,
} from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector:
    '[formControl][disableControl],[ngModel][disableControl],[formControlName][disableControl]',
  standalone: true,
})
export class DisableControlDirective {
  disableControl = input<boolean, boolean | undefined>(true, {
    transform: (value) => {
      return value !== undefined ? booleanAttribute(value) : true;
    },
  });
  private ngControl = inject(NgControl);

  constructor() {
    effect(() => {
      const controlGetter = this.ngControl?.control;
      if (controlGetter) {
        if (this.disableControl()) {
          controlGetter.disable();
        } else {
          controlGetter.enable();
        }
      }
    });
  }
}
