import { Costume } from './costume';

export class ItemsModel<T> {
  items: T[];
  page: number;
  count: number;
  pageCount: number;
}
