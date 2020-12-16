import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../Services/http.service';
import { Book } from '../../Models/Book';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-home',
  styleUrls: ['home.component.css'],
  templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit {

  bookList: Book[] = [];
  dataSource: MatTableDataSource<Book>;
  displayedColumns: string[] = ['id', 'title', 'numberPages', 'price', 'author', 'gender', 'options'];

  constructor(private httpService: HttpService) { }

  slides = [{ 'image': 'https://s1.1zoom.me/big3/793/Library_Book_532388_1920x1080.jpg' },
  { 'image': 'https://aws.traveler.es/prod/designs/v1/assets/2000x1335/162915.jpg' }];

  ngOnInit(): void {
    this.httpService.get("http://localhost:60818/api/books").subscribe((response: Book[]) => {
      this.bookList = response;
      console.log(this.bookList)
      this.dataSource = new MatTableDataSource<Book>(this.bookList);
    })
  }
}