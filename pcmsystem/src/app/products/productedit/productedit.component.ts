import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ProductService } from '../product.service';
import { catchError } from 'rxjs/internal/operators/catchError';
import { throwError } from 'rxjs/internal/observable/throwError';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-productedit',
  templateUrl: './productedit.component.html',
  styleUrls: ['./productedit.component.css'],
})
export class ProducteditComponent {
  editedProduct: any = {
    productId: '',
    productBrand: '',
    productName: '',
    productPrice: 0,
    productQuantity: 0,
    categoryId: '',
  };

  constructor(
    private dialogRef: MatDialogRef<ProducteditComponent>,
    private pservice: ProductService,
    private snackbar: MatSnackBar
  ) {}

  spec: string[] = [];
  specVal: string[] = [];
  specLists: any = [];

  onSubmit(f: any) {
    this.editedProduct.productId = JSON.parse(
      localStorage.getItem('selectedItem')!
    );
    this.editedProduct.productName = f.pName;
    this.editedProduct.productBrand = f.pBrand;
    this.editedProduct.productPrice = f.pPrice;
    this.editedProduct.productQuantity = f.pQuantity;
    this.editedProduct.categoryId = JSON.parse(
      localStorage.getItem('selectedItemCate')!
    );
    console.log(this.editedProduct);

    this.editProduct();

    this.spec = f.pSpec.split(',');
    this.specVal = f.pSpecValue.split(',');

    for (let i = 0; i < this.spec.length; i++) {
      const newSpec = {
        specName: this.spec[i],
        value: this.specVal[i],
        productId: JSON.parse(localStorage.getItem('selectedItem')!),
      };
      this.specLists.push(newSpec);
    }
    this.editProductSpec();
  }

  editProductSpec() {
    this.pservice
      .UpdateProductSpec(this.specLists)
      .pipe(
        catchError((error) => {
          const statusCode = error.status;
          console.log('failed');
          return throwError(error);
        })
      )
      .subscribe((response) => {
        // This is where you can handle the successful response
        this.snackbar.open('Product Added', 'Ok', {
          duration: 3000,
        });
        //location.reload();
      });
  }

  editProduct() {
    this.pservice
      .UpdateProduct(this.editedProduct)
      .pipe(
        catchError((error) => {
          const statusCode = error.status;
          console.log('failed');
          return throwError(error);
        })
      )
      .subscribe((response) => {
        this.snackbar.open('Product updated', 'Ok', {
          duration: 3000,
        });
        location.reload();
      });
  }

  onNoClick() {
    this.dialogRef.close();
  }
}
