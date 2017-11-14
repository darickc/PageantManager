import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageantsComponent } from './pageants.component';

describe('PageantsComponent', () => {
  let component: PageantsComponent;
  let fixture: ComponentFixture<PageantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
