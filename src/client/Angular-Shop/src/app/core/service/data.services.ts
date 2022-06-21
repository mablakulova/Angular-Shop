import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';

@Injectable({
  providedIn: 'root',
})
export class DataService implements InMemoryDbService {
  createDb() {
    return {
      products: [
        {
          id: 10,
          productName: 'Leaf Rake1',
          productCode: 'GDN-0011',
          releaseDate: 'March 19, 2021',
          description: 'Leaf rake with 48-inch wooden handle.',
          price: 19.95,
          starRating: 3.2,
          imageUrl: 'assets/images/leaf_rake.png',
        },
        {
          id: 12,
          productName: 'Garden Cart',
          productCode: 'GDN-0023',
          releaseDate: 'March 18, 2021',
          description: '15 gallon capacity rolling garden cart',
          price: 32.99,
          starRating: 4.2,
          imageUrl: 'assets/images/garden_cart.png',
        },
        {
          id: 15,
          productName: 'Hammer',
          productCode: 'TBX-0048',
          releaseDate: 'May 21, 2021',
          description: 'Curved claw steel hammer',
          price: 8.9,
          starRating: 4.8,
          imageUrl: 'assets/images/hammer.png',
        },
        {
          id: 18,
          productName: 'Saw',
          productCode: 'TBX-0022',
          releaseDate: 'May 15, 2021',
          description: '15-inch steel blade hand saw',
          price: 11.55,
          starRating: 3.7,
          imageUrl: 'assets/images/saw.png',
        },
        {
          id: 20,
          productName: 'Video Game Controller',
          productCode: 'GMG-0042',
          releaseDate: 'October 15, 2020',
          description: 'Standard two-button video game controller',
          price: 35.95,
          starRating: 4.6,
          imageUrl: 'assets/images/xbox-controller.png',
        },
      ],
    };
  }
}
