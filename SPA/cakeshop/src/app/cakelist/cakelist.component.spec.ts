/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CakelistComponent } from './cakelist.component';

describe('CakelistComponent', () => {
  let component: CakelistComponent;
  let fixture: ComponentFixture<CakelistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CakelistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CakelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
