import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CategoryserviceService } from 'src/app/category/categoryservice.service';
import { ProductService } from '../product.service';
import { catchError } from 'rxjs/internal/operators/catchError';
import { throwError } from 'rxjs/internal/observable/throwError';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-addproductdialogue',
  templateUrl: './addproductdialogue.component.html',
  styleUrls: ['./addproductdialogue.component.css'],
})
export class AddproductdialogueComponent {
  constructor(
    private dialogRef: MatDialogRef<AddproductdialogueComponent>,
    private service: CategoryserviceService,
    private pservice: ProductService,
    private snackbar: MatSnackBar
  ) {
    this.selectedOption = this.options[0];
  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.service.getCategories().subscribe((data) => {
      this.listOfCategories = data;
      this.listOfCategories.forEach((element: { categoryName: string }) => {
        this.options.push(element.categoryName);
      });
    });
  }
  listOfCategories: any = [];

  selectedOption: string;
  options: string[] = [];
  spec: string[] = [];
  specVal: string[] = [];
  specLists: any = [];
  newSpec: any = {
    specId: 0,
    specName: '',
    value: '',
    productId: '',
  };
  
  
  newProduct: any = {
    productId: '',
    productBrand: '',
    productName: '',
    productPrice: 0,
    productQuantity: 0,
    categoryId: '',
  };

  prodCount!: any;
  prodId!: string;

  onSubmit(f: any) {
    this.service.getProductCount(f.pCategory).subscribe((data) => {
      this.prodCount = data;
      this.prodId =
        'prod_' +
        f.pName.toLocaleLowerCase().substring(0, 4) +
        '_' +
        this.prodCount;
      this.newProduct.productId = this.prodId;
      this.newProduct.productName = f.pName;
      this.newProduct.productBrand = f.pBrand;
      this.newProduct.productPrice = f.pPrice;
      this.newProduct.productQuantity = f.pQuantity;
      this.newProduct.categoryId =
        'cate_' +
        f.pCategory.toLocaleLowerCase().replace(' ', '').substring(0, 4);
      this.addNew(this.newProduct.categoryId);

      this.spec = f.pSpec.split(',');
      this.specVal = f.pSpecValue.split(',');

      for (let i = 0; i < this.spec.length; i++) {
        const newSpec = {
          specName: this.spec[i],
          value: this.specVal[i],
          productId: this.prodId,
        };
        this.specLists.push(newSpec);
      }

      this.addNewSpec();
      console.log(this.specLists);
    });

    console.log(this.newProduct);
  }
  addNewSpec() {
    this.pservice
      .AddProductSpec(this.specLists)
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
        // location.reload();
      });
  }

  addNew(CateId: string) {
    this.pservice
      .AddProduct(this.newProduct)
      .pipe(
        catchError((error) => {
          const statusCode = error.status;
          console.log('failed');
          return throwError(error);
        })
      )
      .subscribe((response) => {
        this.service.incrementProductCount(CateId).subscribe(
          () => {
            // Handle success or additional logic
            this.snackbar.open('Product Added', 'Ok', {
              duration: 3000,
            });
          },
          (error) => {
            // Handle error
          }
        );
        // This is where you can handle the successful response

        location.reload();
      });
  }
  onNoClick() {
    this.dialogRef.close();
  }
}

interface specList {
  specId: number;
  specName: string;
  value: string;
  productId: string;
}
