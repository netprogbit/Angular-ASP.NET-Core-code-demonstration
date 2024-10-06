import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadChildren: async () => (await import('./layouts/site-layout/site-layout.routes')).SITE_LAYOUT_ROUTES },
];
