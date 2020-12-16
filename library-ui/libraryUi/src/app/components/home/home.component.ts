import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
import { HttpService } from '../../Services/http.service';
import { Book } from '../../Models/Book';
import { MatTableDataSource } from '@angular/material/table';
=======
import { MatCarousel, MatCarouselComponent } from '@ngmodule/material-carousel';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];
>>>>>>> 8d2c53a45e2b9ab40b44fa4f110aedc989a5c1ec


@Component({
  selector: 'app-home',
  styleUrls: ['home.component.css'],
  templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit {

<<<<<<< HEAD
  bookList: Book[] = [];
  dataSource: MatTableDataSource<Book>;
  displayedColumns: string[] = ['id', 'title', 'numberPages', 'price', 'author', 'gender', 'options'];

  constructor(private httpService: HttpService) { }

=======
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
>>>>>>> 8d2c53a45e2b9ab40b44fa4f110aedc989a5c1ec
  slides = [{ 'image': 'https://s1.1zoom.me/big3/793/Library_Book_532388_1920x1080.jpg' },
  { 'image': 'https://aws.traveler.es/prod/designs/v1/assets/2000x1335/162915.jpg' }];

  ngOnInit(): void {
<<<<<<< HEAD
    this.httpService.get("http://localhost:60818/api/books").subscribe((response: Book[]) => {
      this.bookList = response;
      console.log(this.bookList)
      this.dataSource = new MatTableDataSource<Book>(this.bookList);
    })
=======

>>>>>>> 8d2c53a45e2b9ab40b44fa4f110aedc989a5c1ec
  }
}