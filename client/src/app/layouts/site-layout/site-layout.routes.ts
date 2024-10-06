import { Routes } from '@angular/router';
import { SiteLayoutComponent } from './site-layout.component';

export const SITE_LAYOUT_ROUTES: Routes = [
  {
    path: '',
    component: SiteLayoutComponent,
    children: [
      { path: '', loadComponent: async () => (await import('../../pages/product-list/product-list.component')).ProductListComponent },
      { path: 'product-edit/:id', loadComponent: async () => (await import('../../pages/product-edit/product-edit.component')).ProductEditComponent },
    ],
  },  
];