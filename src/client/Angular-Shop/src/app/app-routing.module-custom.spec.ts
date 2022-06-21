import { Component } from '@angular/core';
import { TestBed, fakeAsync, tick, async, ComponentFixture } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { routes } from './app-routing.module';
import { HomeComponent } from './modules/home/home.component';
import { Location } from '@angular/common';

@Component({
  selector: 'routing-test-cmp',
  template: `<router-outlet></router-outlet>`,
})
class RoutingTestComponent {}

describe('The App Routing (with custom cmp)', () => {
  let routingComponentFixture: ComponentFixture<RoutingTestComponent>;
  let routingComponent: RoutingTestComponent;
  let router: Router;
  let location: Location;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule.withRoutes(routes)],
      declarations: [HomeComponent, RoutingTestComponent],
    });

    routingComponentFixture = TestBed.createComponent(RoutingTestComponent);
    routingComponent = routingComponentFixture.componentInstance;

    router = TestBed.get(Router) as Router;
    location = TestBed.get(Location) as Location;
  });

  it('should properly redirect to home initially', async(() => {
    router.navigate(['']);
    routingComponentFixture.whenStable().then(() => {
      expect(location.path()).toBe('/home');
    });
  }));
});
