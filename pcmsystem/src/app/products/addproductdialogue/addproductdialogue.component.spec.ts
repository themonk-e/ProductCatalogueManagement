import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddproductdialogueComponent } from './addproductdialogue.component';

describe('AddproductdialogueComponent', () => {
  let component: AddproductdialogueComponent;
  let fixture: ComponentFixture<AddproductdialogueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddproductdialogueComponent]
    });
    fixture = TestBed.createComponent(AddproductdialogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
