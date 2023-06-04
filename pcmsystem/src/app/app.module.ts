import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { HomeComponent } from './home/home.component';
import { CategorycompComponent } from './category/categorycomp/categorycomp.component';
import { MatTableModule } from '@angular/material/table';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AddCategoryDialogueComponent } from './category/add-category-dialogue/add-category-dialogue.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ProductDisplayComponent } from './products/product-display/product-display.component';
import { MatCardModule } from '@angular/material/card';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { ViewProductComponent } from './products/view-product/view-product.component';
import { AddproductdialogueComponent } from './products/addproductdialogue/addproductdialogue.component';
import { MatSelectModule } from '@angular/material/select';
import { ProducteditComponent } from './products/productedit/productedit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CategorycompComponent,
    AddCategoryDialogueComponent,
    ProductDisplayComponent,
    ViewProductComponent,
    AddproductdialogueComponent,
    ProducteditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    FlexLayoutModule,
    MatButtonModule,
    MatTableModule,
    HttpClientModule,
    MatDialogModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    MatCardModule,
    MatIconModule,
    MatSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
