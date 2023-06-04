import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {}

  baseUrl: string = 'https://localhost:7247';

  getProducts() {
    return this.http.get(this.baseUrl + '/api/Product/get/all/Products');
  }

  filterByBrand(brand: any) {
    return this.http.get(this.baseUrl + '/api/Product/get/byBrand/' + brand);
  }

  cate!: string;
  filterByCategory(category: any) {
    return this.http.get(
      this.baseUrl + '/api/Product/get/byCategory/' + category
    );
  }

  getAProduct(productId: string) {
    return this.http.get(
      this.baseUrl + '/api/Product/get/product/' + productId
    );
  }

  getAProductSpec(productId: string) {
    return this.http.get(
      this.baseUrl + '/api/ProductSpec/get/speclist/' + productId
    );
  }

  AddProduct(product: any) {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(product);
    return this.http.post(this.baseUrl + '/api/Product/add/new/product', body, {
      headers: headers,
    });
  }

  AddProductSpec(specList: any) {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(specList);
    return this.http.post(this.baseUrl + '/api/ProductSpec/add/specs', body, {
      headers: headers,
    });
  }

  DeleteProduct(productId: string) {
    return this.http.delete(
      this.baseUrl + '/api/Product/Delete/product/' + productId
    );
  }

  DeleteProductSpec(productId: string) {
    return this.http.delete(
      this.baseUrl + '/api/ProductSpec/delete/spec/' + productId
    );
  }

  UpdateProduct(product: any) {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(product);
    return this.http.put(this.baseUrl + '/api/Product/update/product', body, {
      headers: headers,
    });
  }

  UpdateProductSpec(specList: any) {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(specList);
    return this.http.put(this.baseUrl + '/api/ProductSpec/update/specs', body, {
      headers: headers,
    });
  }
}
