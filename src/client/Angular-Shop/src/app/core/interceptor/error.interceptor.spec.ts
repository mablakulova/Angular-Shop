import { throwError } from 'rxjs';
import { AuthenticationService } from '../service/authentication.service';
import { ErrorInterceptor } from './error.interceptor';

describe('ErrorInterceptor', () => {
  let interceptor;
  let authServiceSpy;

  beforeEach(() => {
    authServiceSpy = jasmine.createSpyObj('AuthenticationService', ['logout']);
    interceptor = new ErrorInterceptor(authServiceSpy);
  });

  it('it should be created', () => {
    expect(interceptor).toBeTruthy();
  });

  describe('intercept', () => {
    let httpRequestSpy;
    let httpHandlerSpy;
    const error = { status: 401, statusText: 'error' };

    it('should auto logout if 401 response returned from api', () => {
      httpRequestSpy = jasmine.createSpyObj('HttpRequest', ['testError']);
      httpHandlerSpy = jasmine.createSpyObj('HttpHandler', ['handle']);
      httpHandlerSpy.handle.and.returnValue(throwError({ error: { message: 'test-error' } }));

      interceptor.intercept(httpRequestSpy, httpHandlerSpy).subscribe((err) => {
        expect(err).toEqual('test-error');
      });
    });
  });
});
