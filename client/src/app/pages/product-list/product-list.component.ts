import { Component, inject, Signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from '../../core/services/http.service';
import { IProductDto } from '../../core/services/models/dto/product-dto.interface';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
  ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss'
})
export class ProductListComponent {
  private _httpService = inject(HttpService);
  private _router = inject(Router);

  protected productsSignal: Signal<IProductDto[] | undefined> = toSignal(this._httpService.getProducts());

  protected editProduct(productId: number) {
    this._router.navigate(['/product-edit', productId]);
  }
}
