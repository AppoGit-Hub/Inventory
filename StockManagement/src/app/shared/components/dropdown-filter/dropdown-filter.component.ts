import { Component, Input, input, inject } from '@angular/core';
import {
  FilterService,
  BaseFilterCellComponent,
} from '@progress/kendo-angular-grid';
import { KENDO_DROPDOWNS } from '@progress/kendo-angular-dropdowns';
import { CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { TranslocoService } from '@jsverse/transloco';

@Component({
  selector: 'app-dropdown-filter',
  templateUrl: 'dropdown-filter.component.html',
  imports: [KENDO_DROPDOWNS],
  standalone: true,
})
export class DropDownListFilterComponent extends BaseFilterCellComponent {
  public get selectedValue(): unknown {
    const filter = this.filterByField(this.valueField());
    return filter ? filter.value : null;
  }

  // NOTE: restriction from Kendo, we cannot use the Input signal here
  @Input() public override filter: CompositeFilterDescriptor = null!;
  public data = input.required<{ text: string; value: unknown }[]>();
  public valueField = input.required<string>();

  public translationService = inject(TranslocoService);

  public get defaultItem(): { [Key: string]: unknown } {
    return {
      text: this.translationService.translate('labels.select'),
      value: null,
    };
  }

  constructor(filterService: FilterService) {
    super(filterService);
  }

  public onChange(value: unknown): void {
    this.applyFilter(
      value !== null && value !== undefined
        ? this.updateFilter({
            field: this.valueField(),
            operator: 'eq',
            value: value,
          })
        : this.removeFilter(this.valueField()),
    );
  }
}
