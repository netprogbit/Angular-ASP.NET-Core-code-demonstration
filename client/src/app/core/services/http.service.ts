import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { IProductDto } from './models/dto/product-dto.interface';
import { IProductUpdateDto } from './models/dto/update-product-dto.interface';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private _httpClient = inject(HttpClient);

  public updateProduct(id: number | undefined, request: IProductUpdateDto): Observable<void> {
    const uri = `${environment.apiUrl}/products/${id}`;
    return this._httpClient.put<void>(uri, request);
  }

  public getProducts(): Observable<IProductDto[]> {
    const uri = `${environment.apiUrl}/products`;
    return this._httpClient.get<IProductDto[]>(uri);
  }

  public getProductById(id: string | null): Observable<IProductDto> {
    const uri = `${environment.apiUrl}/products/${id}`;
    return this._httpClient.get<IProductDto>(uri);
  }
}
