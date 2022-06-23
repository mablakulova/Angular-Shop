import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IProduct } from '../shared/product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private productUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts(): Observable<IProduct[]> {
    return this.http.get<IProduct[]>(this.productUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(error);
      }),
    );
  }

  // Get one product
  getProduct(id: number): Observable<IProduct | undefined> {
    return this.getProducts().pipe(
      map(
        (products: IProduct[] | any) => products.find((p) => p.id === id),
        catchError((error: HttpErrorResponse) => {
          return throwError(error);
        }),
      ),
    );
  }

  // Create product
  createProduct(product: IProduct): Observable<any> {
    return this.http.post(this.productUrl, product);
  }
}
 