import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/Models/Book';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  book;
  reviews;
  product: Book = new Book;
  constructor(private httpService:HttpService,private route: ActivatedRoute) { }

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get("Id");
    this.book = this.httpService.get(`http://localhost:60818/api/books/${id}`).subscribe((response: Book)=>{
      this.product = response;
      this.reviews = this.product.reviewList;
      console.log(this.product);
      console.log(this.reviews);
      
    });
  }
}
