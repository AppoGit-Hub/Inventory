import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DropDownListFilterComponent } from './dropdown-filter.component';

describe('DropDownListFilterComponent', () => {
  let component: DropDownListFilterComponent;
  let fixture: ComponentFixture<DropDownListFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DropDownListFilterComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DropDownListFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
