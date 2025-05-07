import {
  Directive,
  HostListener,
  input,
  OnDestroy,
  output,
} from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Directive({
  selector: '[afterValueChanged]',
  standalone: true,
})
export class AfterValueChangedDirective implements OnDestroy {
  public afterValueChanged = output<number>();
  public valueChangeDelay = input<number>(300);

  private stream: Subject<number> = new Subject<number>();
  private subscription: Subscription;

  constructor() {
    this.subscription = this.stream
      .pipe(debounceTime(this.valueChangeDelay()))
      .subscribe((value: number) => this.afterValueChanged.emit(value));
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  @HostListener('valueChange', ['$event'])
  public onValueChange(value: number): void {
    this.stream.next(value);
  }
}
