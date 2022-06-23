import { fakeAsync, TestBed, tick } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { AppModule } from './app.module';
import { routes } from './app-routing.module';
import { Location } from '@angular/common';

describe('The App Routing', () => {
  let router: Router;
  let location: Location;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [AppModule, RouterTestingModule.withRoutes(routes)],
    });

    router = TestBed.get(Router) as Router;
    location = TestBed.get(Location) as Location;
  });

  it('automatically redirects to /auth when invoking auth', fakeAsync(() => {
    router.navigate(['auth']);
    tick();

    expect(location.path()).toBe('/auth');
  }));

  it('automatically redirects to unauthorized when invoking products', fakeAsync(() => {
    router.navigate(['/products']);
    tick();

    expect(location.path()).toBe('/auth/unauthorized?returnUrl=%2Fproducts');
  }));
});
