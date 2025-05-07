import {
  BaseFilterCellComponent,
  FilterService,
} from '@progress/kendo-angular-grid';
import { InputSignal } from '@angular/core';
import { FilterDescriptor } from '@progress/kendo-data-query';
import { filterClearIcon, filterIcon } from '@progress/kendo-svg-icons';

export abstract class RangeFilterComponent extends BaseFilterCellComponent {
  public abstract field: InputSignal<string>;

  public dialogOpened = false;

  readonly filterClearIcon = filterClearIcon;
  readonly filterIcon = filterIcon;

  protected constructor(filterService: FilterService) {
    super(filterService);
  }

  public openDialog(): void {
    this.dialogOpened = true;
  }

  public closeDialog(): void {
    this.dialogOpened = false;
  }

  public get start(): unknown {
    const first = this.findByOperator('gte');

    return (first || <FilterDescriptor>{}).value;
  }

  public get end(): unknown {
    const end = this.findByOperator('lte');
    return (end || <FilterDescriptor>{}).value;
  }

  public get hasFilter(): boolean {
    return this.filtersByField(this.field()).length > 0;
  }

  public clearFilter(): void {
    this.filterService.filter(this.removeFilter(this.field()));
  }

  // NOTE: unknown because we let the subclass implementation decide the type
  public filterRange(start: unknown | null, end: unknown | null): void {
    this.filter = this.removeFilter(this.field());

    const filters = [];

    if (start !== null) {
      filters.push({
        field: this.field(),
        operator: 'gte',
        value: start,
      });
    }

    if (end !== null) {
      filters.push({
        field: this.field(),
        operator: 'lte',
        value: end,
      });
    }

    const root = this.filter || {
      logic: 'and',
      filters: [],
    };

    if (filters.length) {
      root.filters.push(...filters);
    }

    this.filterService.filter(root);
  }

  private findByOperator(op: string): FilterDescriptor {
    return this.filtersByField(this.field()).filter(
      ({ operator }) => operator === op,
    )[0];
  }
}
