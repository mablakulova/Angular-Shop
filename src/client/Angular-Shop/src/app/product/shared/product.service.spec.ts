import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ProductService } from './product.service';
import { IProduct } from '../shared/product';

describe('ProductService', () => {
  let service: ProductService;
  let httpController: HttpTestingController;
  const apiUrl = 'https://localhost:7123/api/Products';

  // eslint-disable-next-line no-undef
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProductService],
    });

    // inject service
    service = TestBed.inject(ProductService);
    httpController = TestBed.inject(HttpTestingController);
  });

  it('should have a service instance', () => {
    expect(service).toBeDefined();
  });

  it('should call getProduct and return the appropriate Product', () => {
    const mockProduct1: IProduct = {
      id: 1,
      productName: 'Leaf Rake1',
      productCode: 'GDN-0011',
      releaseDate: 'March 19, 2021',
      description: 'Leaf rake with 48-inch wooden handle.',
      price: 19.95,
      starRating: 3.2,
      imageUrl: 'assets/images/leaf_rake.png',
    };

    const id = 1;

    service.getProduct(id).subscribe((data) => {
      expect(data).toEqual(mockProduct1);
    });

    const req = httpController.expectOne(apiUrl);

    expect(req.request.method).toBe('GET');

    req.flush(mockProduct1);
  });

  it('returns products with an id <= 2', () => {
    const mockResponse = [
      {
        id: 1,
        productName: 'Leaf Rake1',
        productCode: 'GDN-0011',
        releaseDate: 'March 19, 2021',
        description: 'Leaf rake with 48-inch wooden handle.',
        price: 19.95,
        starRating: 3.2,
        imageUrl: 'assets/images/leaf_rake.png',
      },
      {
        id: 2,
        productName: 'Garden Cart',
        productCode: 'GDN-0023',
        releaseDate: 'March 18, 2021',
        description: '15 gallon capacity rolling garden cart',
        price: 10.95,
        starRating: 4.2,
        imageUrl: 'assets/images/garden_cart.png',
      },
    ];

    service.getProducts().subscribe((actualProducts) => {
      expect(actualProducts.length).toBe(2);
      expect(actualProducts[0].id).toEqual(1);
    });

    const req = httpController.expectOne(apiUrl);
    expect(req.request.method).toEqual('GET');

    req.flush(mockResponse);
    httpController.verify();
  });

  it('should call createProduct and return the product that was added', () => {
    const mockProduct2: IProduct = {
      id: 6,
      productName: 'Logo FCB',
      productCode: 'GDN-0022',
      releaseDate: 'March 19, 2023',
      description: 'Logo logo FCB FCB',
      price: 10,
      starRating: 4,
      imageUrl: 'assets/images/logo-fcb.png',
    };
    service.createProduct(mockProduct2).subscribe((data) => {
      expect(data.productName).toEqual('Logo FCB');
      expect(data.productCode).toEqual('GDN-0022');
      expect(data.description).toEqual('Logo logo FCB FCB');
    });

    const req = httpController.expectOne({
      method: 'POST',
      url: apiUrl,
    });

    req.flush(mockProduct2);
  });
});
