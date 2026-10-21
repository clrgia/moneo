import { Component, inject, computed } from '@angular/core';
import { Stat } from '../../components/stat/stat';
import { DecimalPipe } from '@angular/common';
import { Category } from '../../components/category/category';
import { Table } from '../../components/table/table';
import { AccountService } from '../../services/account';
import { toSignal } from '@angular/core/rxjs-interop';


@Component({
  imports: [Stat, DecimalPipe, Category, Table],
  selector: 'app-overview-page',
  styleUrl: './overview-page.css',
  templateUrl: './overview-page.html',
})
export class OverviewPage {
  private accountService = inject(AccountService);
  public accounts = toSignal(this.accountService.getAll(), { initialValue: [] });

  public totalBalance = computed(() =>
    this.accounts().reduce((total, account) => total + account.currentBalance, 0),
  );

  public categories = [
    { label: 'Housing', percentage: 50 },
    { label: 'Food & Groceries', percentage: 20 },
    { label: 'Transportation', percentage: 10 },
    { label: 'Entertainment', percentage: 10 },
    { label: 'Miscellaneous', percentage: 10 },
  ];

  public operations = [
    { label: 'Freelance invoice #42', date: new Date(2026, 9, 1), amount: 650 },
    { label: 'Internet box', date: new Date(2026, 9, 2), amount: -29.99 },
    { label: 'Vinted sale', date: new Date(2026, 9, 5), amount: 35 },
  ];
}
