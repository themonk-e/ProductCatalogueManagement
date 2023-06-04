import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CategoryserviceService } from '../categoryservice.service';
import { catchError } from 'rxjs/internal/operators/catchError';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Route, Router } from '@angular/router';
@Component({
  selector: 'app-add-category-dialogue',
  templateUrl: './add-category-dialogue.component.html',
  styleUrls: ['./add-category-dialogue.component.css'],
})
export class AddCategoryDialogueComponent {
  newCategory: Category = {
    categoryId: '',
    categoryDescription: 0,
    categoryName: '',
    categoryProductCount: 0,
  };
  cateId!: string;

  constructor(
    private dialogRef: MatDialogRef<AddCategoryDialogueComponent>,
    private service: CategoryserviceService,
    private snackbar: MatSnackBar,
    private router: Router
  ) {}
  onSubmit(f: any) {
    this.cateId = f.category;
    this.newCategory.categoryId =
      'cate_' +
      this.cateId.toLocaleLowerCase().replace(' ', '').substring(0, 4);
    this.newCategory.categoryDescription = 0;
    this.newCategory.categoryName = this.cateId;
    this.newCategory.categoryProductCount = 0;
    console.log(f.category);

    this.service
      .addNewCategory(this.newCategory)
      .pipe(
        catchError((error) => {
          const statusCode = error.status;
          console.log('failed');
          return throwError(error);
        })
      )
      .subscribe((response) => {
        // This is where you can handle the successful response
        this.snackbar.open('Category Added', 'Ok', {
          duration: 3000,
        });
        location.reload();
      });
  }

  // get(f: any) {
  //   this.cateId = f;
  // }

  onNoClick() {
    this.dialogRef.close();
  }
}
interface Category {
  categoryId: string;
  categoryName: string;
  categoryDescription: 0;
  categoryProductCount: number;
}
function throwError(error: any): any {
  throw new Error('Function not implemented.');
}
