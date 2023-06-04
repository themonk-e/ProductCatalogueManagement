import { Component } from '@angular/core';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { ProducteditComponent } from '../productedit/productedit.component';
import { MatDialog } from '@angular/material/dialog';
import { CategoryserviceService } from 'src/app/category/categoryservice.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css'],
})
export class ViewProductComponent {
  constructor(
    private service: ProductService,
    private router: Router,
    private dialog: MatDialog,
    private cservice: CategoryserviceService
  ) {}

  specList: any = [];

  selected: any = {
    productId: '',
    productBrand: '',
    productName: '',
    productPrice: 0,
    productQuantity: 0,
    categoryId: '',
  };
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getProduct();
    this.getProductSpec();
  }
  prodId!: string;
  getProduct() {
    this.prodId = JSON.parse(localStorage.getItem('selectedItem')!);
    this.service.getAProduct(this.prodId).subscribe((data) => {
      this.selected = data;
    });
  }

  getProductSpec() {
    this.prodId = JSON.parse(localStorage.getItem('selectedItem')!);
    this.service.getAProductSpec(this.prodId).subscribe((data) => {
      this.specList = data;
    });
  }

  deleteProduct(prodId: string) {
    this.service.DeleteProductSpec(prodId).subscribe(
      () => {
        this.service.DeleteProduct(prodId).subscribe(
          () => {
            this.cservice
              .decrementProductCount(
                JSON.parse(localStorage.getItem('selectedItemCate')!)
              )
              .subscribe(() => {
                this.router.navigate(['']);
              });
          },
          (error) => {
            // Handle error
          }
        );
      },
      (error) => {
        // Handle error
      }
    );
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ProducteditComponent, {
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
