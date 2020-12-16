import { Review } from "./Review";

export class Book {
  id: number;
  title: string;
  numberPages: string;
  gender: string;
  author: string;
  price: number;
  reviewList: Review[];
}