import { Component, input, Input } from '@angular/core';
import { FilterService } from '@progress/kendo-angular-grid';
import { CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { KENDO_BUTTONS } from '@progress/kendo-angular-buttons';
import { FormsModule } from '@angular/forms';
import { KENDO_INPUTS } from '@progress/kendo-angular-inputs';
import { KENDO_DIALOGS } from '@progress/kendo-angular-dialog';
import { TranslocoDirective } from '@jsverse/transloco';

import { AfterValueChangedDirective } from '@directives/after-value-changed.directive';
import { RangeFilterComponent } from '@components/range-filters/range-filter.component';

@Component({
  selector: 'app-numeric-range-filter',
  templateUrl: 'numeric-range-filter.component.html',
  imports: [
    KENDO_BUTTONS,
    KENDO_DIALOGS,
    KENDO_INPUTS,
    AfterValueChangedDirective,
    FormsModule,
    TranslocoDirective,
  ],
  standalone: true,
})
export class NumericRangeFilterComponent extends RangeFilterComponent {
  // NOTE: restriction from Kendo, we cannot use the Input signal here
  @Input() public override filter: CompositeFilterDescriptor = null!;
  public override field = input.required<string>();

  constructor(filterService: FilterService) {
    super(filterService);
  }

  public override get start(): number | null {
    return super.start as number | null;
  }

  public override get end(): number | null {
    return super.end as number | null;
  }

  public filterBetween(
    start: number | undefined | null,
    end: number | undefined | null,
  ): void {
    super.filterRange(
      start !== null && start !== undefined ? start : null,
      end !== null && end !== undefined ? end : null,
    );
  }
}
