import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../product.service';
import { Dialog } from '@angular/cdk/dialog';
import { MatDialog } from '@angular/material/dialog';
import { AddproductdialogueComponent } from '../addproductdialogue/addproductdialogue.component';

@Component({
  selector: 'app-product-display',
  templateUrl: './product-display.component.html',
  styleUrls: ['./product-display.component.css'],
})
export class ProductDisplayComponent {
  constructor(
    private service: ProductService,
    private route: Router,
    private dialog: MatDialog
  ) {}

  listOfProducts: any = [];
  listByBrand: any = [];
  listByCategory: any = [];
  empty: boolean = false;
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.empty = false;
    this.getProduct();
  }
  getProduct() {
    this.service.getProducts().subscribe((data) => {
      this.listOfProducts = data;
    });
  }

  viewAll() {
    location.reload();
  }

  onSubmit(f: any) {
    console.log(f.category);

    this.service.filterByBrand(f.category).subscribe((data) => {
      this.listByBrand = data;
      console.log(this.listByBrand);

      if (this.listByBrand[0] == null) {
        this.service
          .filterByCategory(
            'cate_' +
              f.category.toLocaleLowerCase().replace(' ', '').substring(0, 4)
          )
          .subscribe((data) => {
            this.listByCategory = data;
            if (this.listByCategory[0] == null) {
              this.empty = true;
            } else {
              this.listOfProducts = this.listByCategory;
            }
          });
      } else {
        this.listOfProducts = this.listByBrand;
      }
    });
  }

  viewAProduct(prodId: string, cateId: string) {
    console.log(prodId);

    localStorage.setItem('selectedItem', JSON.stringify(prodId));
    localStorage.setItem('selectedItemCate', JSON.stringify(cateId));
    this.route.navigate(['viewProduct']);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddproductdialogueComponent, {
      data: {},
      width: '35%',
    });
  }
}

interface productObj {
  productId: string;
  productName: string;
  productPrice: number;
  productQuantity: number;
  productBrand: string;
  categoryId: string;
}
