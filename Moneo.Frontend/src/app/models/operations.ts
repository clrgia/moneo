export interface IOperations {
  id: string;
  label: string;
  amount: number;
  date: string;
  accountId: string;
  categoryId?: string;
  categoryLabel?: string;
}
