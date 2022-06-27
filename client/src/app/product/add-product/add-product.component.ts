import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/product/shared/product.service';
import { IProduct } from '../shared/product';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  newProduct: IProduct;

  constructor(private router: Router, private productService: ProductService,
    private dialogRef: MatDialogRef<AddProductComponent>) {}

  ngOnInit(): void {
    this.newProduct = new IProduct();
  }

  handleImageUpload(imageDataUrl: string) {
    this.newProduct.imageUrl = imageDataUrl;
  }

  createProduct() {
    this.productService.createProduct(this.newProduct).subscribe((product: IProduct) => {
      this.router.navigate([`/products/${product.id}`]);
      this.dialogRef.close();
    });
  }
}
