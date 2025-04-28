import { Component, input, Input } from '@angular/core';
import { FilterService } from '@progress/kendo-angular-grid';
import { CompositeFilterDescriptor } from '@progress/kendo-data-query';
import {
  KENDO_DATEINPUTS,
  KENDO_DATETIMEPICKER,
} from '@progress/kendo-angular-dateinputs';
import { KENDO_BUTTONS } from '@progress/kendo-angular-buttons';
import { DatePipe, NgStyle } from '@angular/common';
import {
  DialogActionsComponent,
  DialogComponent,
} from '@progress/kendo-angular-dialog';
import { TranslocoDirective } from '@jsverse/transloco';

import { AfterValueChangedDirective } from '@directives/after-value-changed.directive';
import { RangeFilterComponent } from '@components/range-filters/range-filter.component';

@Component({
  selector: 'app-date-range-filter',
  templateUrl: 'date-range-filter.component.html',
  imports: [
    KENDO_BUTTONS,
    KENDO_DATETIMEPICKER,
    KENDO_DATEINPUTS,
    AfterValueChangedDirective,
    DialogActionsComponent,
    DialogComponent,
    DatePipe,
    TranslocoDirective,
  ],
  standalone: true,
})
export class DateRangeFilterComponent extends RangeFilterComponent {
  // NOTE: restriction from Kendo, we cannot use the Input signal here
  @Input() public override filter: CompositeFilterDescriptor = null!;
  public override field = input.required<string>();

  constructor(filterService: FilterService) {
    super(filterService);
  }

  public override get start(): Date | null {
    return super.start ? new Date(super.start as string) : null;
  }

  public override get end(): Date | null {
    return super.end ? new Date(super.end as string) : null;
  }

  public filterBetween(
    start: Date | number | null,
    end: Date | number | null,
  ): void {
    super.filterRange(
      start !== null ? new Date(start).toISOString() : null,
      end !== null ? new Date(end).toISOString() : null,
    );
  }
}
