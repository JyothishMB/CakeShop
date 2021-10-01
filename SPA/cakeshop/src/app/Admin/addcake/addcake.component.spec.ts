/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddcakeComponent } from './addcake.component';

describe('AddcakeComponent', () => {
  let component: AddcakeComponent;
  let fixture: ComponentFixture<AddcakeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddcakeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddcakeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
