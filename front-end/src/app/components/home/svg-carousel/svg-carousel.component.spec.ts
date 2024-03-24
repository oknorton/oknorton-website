import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SvgCarouselComponent } from './svg-carousel.component';

describe('SvgCarouselComponent', () => {
  let component: SvgCarouselComponent;
  let fixture: ComponentFixture<SvgCarouselComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SvgCarouselComponent]
    });
    fixture = TestBed.createComponent(SvgCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
