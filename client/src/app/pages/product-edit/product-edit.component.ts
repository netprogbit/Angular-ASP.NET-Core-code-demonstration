import { CommonModule } from '@angular/common';
import { Component, OnInit, inject, DestroyRef, WritableSignal, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpService } from '../../core/services/http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Observable, map, switchMap } from 'rxjs';
import { IProductDto } from '../../core/services/models/dto/product-dto.interface';
import { IProductUpdateDto } from '../../core/services/models/dto/update-product-dto.interface';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
  ],
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.scss'
})
export class ProductEditComponent implements OnInit {
  private _httpService = inject(HttpService);
  private _router = inject(Router);
  private _route = inject(ActivatedRoute);
  private _destroyRef = inject(DestroyRef);
  private _productId$: Observable<string> = this._route.params.pipe(map(params => params['id']));
  private _product$: Observable<IProductDto> = this._productId$.pipe(
    switchMap(id => {
      return this._httpService.getProductById(id);
    }),
  );

  protected idSignal: WritableSignal<number> = signal(0);
  protected nameSignal: WritableSignal<string> = signal('');
  protected descriptionSignal: WritableSignal<string> = signal('');
  protected priceSignal: WritableSignal<number> = signal(0);

  ngOnInit() {
    this._product$
      .pipe(takeUntilDestroyed(this._destroyRef))
      .subscribe((category: IProductDto) => {
        this.idSignal.set(category.id);
        this.nameSignal.set(category.name);
        this.descriptionSignal.set(category.description);
        this.priceSignal.set(category.price);
      });
  }

  protected save() {
    const productUpdateDto: IProductUpdateDto = { name: this.nameSignal(), description: this.descriptionSignal(), price: this.priceSignal() };
    this._httpService.updateProduct(this.idSignal(), productUpdateDto)
    .pipe(takeUntilDestroyed(this._destroyRef))
    .subscribe(() => {
      this._router.navigate(['/']);
    });
  }
}
