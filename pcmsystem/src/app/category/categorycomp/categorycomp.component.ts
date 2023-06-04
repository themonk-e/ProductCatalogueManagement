import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CategoryserviceService } from '../categoryservice.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { AddCategoryDialogueComponent } from '../add-category-dialogue/add-category-dialogue.component';

@Component({
  selector: 'app-categorycomp',
  templateUrl: './categorycomp.component.html',
  styleUrls: ['./categorycomp.component.css'],
})
export class CategorycompComponent {
  constructor(
    private service: CategoryserviceService,
    private dialog: MatDialog
  ) {}

  dataSource: any;
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getCategories();
  }

  categories: any = [];

  openDialog(): void {
    const dialogRef = this.dialog.open(AddCategoryDialogueComponent, {
      data: {},
      width: '35%',
    });
  }

  getCategories() {
    this.service.getCategories().subscribe((data) => {
      this.categories = data;
      this.dataSource = new MatTableDataSource(this.categories);
    });
  }

  deleteCategory(cateId: any) {
    this.service.deleteCategory(cateId).subscribe(
      () => {
        // Handle success or additional logic
        location.reload();
      },
      (error) => {
        // Handle error
      }
    );
  }

  ///dataSource = new MatTableDataSource(this.categories);
  displayedColumns: string[] = ['Category', 'Product Count', 'Delete'];
}

interface Category {
  categoryId: string;
  categoryName: string;
  categoryDescription: 0;
  categoryProductCount: number;
}
