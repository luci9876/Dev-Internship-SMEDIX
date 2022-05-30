import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateDetailsParentContainerComponent } from './candidate-details-parent-container.component';

describe('CandidateDetailsParentContainerComponent', () => {
  let component: CandidateDetailsParentContainerComponent;
  let fixture: ComponentFixture<CandidateDetailsParentContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CandidateDetailsParentContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidateDetailsParentContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
