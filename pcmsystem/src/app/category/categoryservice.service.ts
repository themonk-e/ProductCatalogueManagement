import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ProductService } from '../products/product.service';

@Injectable({
  providedIn: 'root',
})
export class CategoryserviceService {
  constructor(private http: HttpClient, private pService: ProductService) {}

  baseUrl: string = 'https://localhost:7247';
  listOfProducts: any = [];

  getCategories() {
    return this.http.get(this.baseUrl + '/api/Category/get/all/Categories');
  }

  addNewCategory(cate: Category) {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(cate);
    return this.http.post(
      this.baseUrl + '/api/Category/add/newCategory',
      body,
      { headers: headers }
    );
  }

  getProductCount(cate: string) {
    return this.http.get(
      this.baseUrl +
        '/api/Category/category/product/count/' +
        'cate_' +
        cate.toLowerCase().replace(' ', '').substring(0, 4)
    );
  }

  deleteCategory(cateId: string) {
    console.log(cateId);

    return this.http.delete(
      this.baseUrl + '/api/Category/category/delete/category/' + cateId
    );
  }

  incrementProductCount(cateId: string) {
    const headers = { 'content-type': 'application/json' };
    const body = '';
    return this.http.put(
      this.baseUrl + '/api/Category/category/update/product/count/' + cateId,
      body,
      { headers: headers }
    );
  }

  decrementProductCount(cateId: string) {
    const headers = { 'content-type': 'application/json' };
    const body = '';
    return this.http.put(
      this.baseUrl + '/api/Category/category/decrement/product/count/' + cateId,
      body,
      { headers: headers }
    );
  }
}
interface Category {
  categoryId: string;
  categoryName: string;
  categoryDescription: 0;
  categoryProductCount: number;
}
