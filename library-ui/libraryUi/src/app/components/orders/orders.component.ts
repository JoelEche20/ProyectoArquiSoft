import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Order } from 'src/app/Models/Order';
import { HttpService } from 'src/app/Services/http.service';
import { AddOrdersComponent } from '../add-orders/add-orders.component';
import { MatDialog} from '@angular/material/dialog';
import { Input } from '@angular/core';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  ordersList: Order[] = [];
  dataSource: MatTableDataSource<Order>;
  displayedColumns: string[] = ['id', 'price', 'phone', 'address', 'idUser', 'idBook', 'options'];
  data;
  @Input() id: number;
  constructor(private httpService: HttpService,public dialog: MatDialog) { }

  slides = [{ 'image': 'https://www.upr.edu/biblioteca-rcm/wp-content/uploads/sites/71/2017/05/circ.png' },
  { 'image': 'https://www.knowsleynews.co.uk/wp-content/uploads/2016/06/Woman-holds-out-book-1170x775.jpg' },
  { 'image': 'https://www.napolike.it/wp-content/uploads/2020/03/libri.jpg'}];

  ngOnInit(): void {
    this.httpService.get("https://localhost:44384/api/orders").subscribe((response: Order[]) => {
      this.ordersList = response;
      this.dataSource = new MatTableDataSource<Order>(this.ordersList);
    })

  }

  openDialogAdd() {
    const dialogRef = this.dialog.open(AddOrdersComponent, { data: this.id, width: "500px" });
    dialogRef.afterClosed().subscribe(res => {
      if (res) {
        this.data.push(res["data"]);
        this.dataSource = new MatTableDataSource(this.data);
      }
    })
  }

}
