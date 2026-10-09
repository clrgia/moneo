import { Routes } from '@angular/router';
import { OverviewPage } from './pages/overview-page/overview-page';
import { AccountsPage } from './pages/accounts-page/accounts-page';

export const routes: Routes = [
    { path: '', component: OverviewPage},
    { path: 'accounts', component: AccountsPage }
];
