import { Component, ElementRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HighlightDirective } from './highlight.directive';

@Component({
  template: `<input type="text" hoverfocus />`,
})
class TestComponent {}

describe('HighlightDirective', () => {
  let component: TestComponent;
  let fixture: ComponentFixture<TestComponent>;
  let ef: ElementRef;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TestComponent, HighlightDirective],
    });
    fixture = TestBed.createComponent(TestComponent);
    component = fixture.componentInstance;
  });

  it('should create an instance', () => {
    const directive = new HighlightDirective(ef);
    expect(directive).toBeTruthy();
  });
});
