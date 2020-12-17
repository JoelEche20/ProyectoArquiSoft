import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/Models/Order';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpService } from 'src/app/Services/http.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {MatSnackBar}from '@angular/material/snack-bar'
import { Inject } from '@angular/core';



@Component({
  selector: 'app-add-orders',
  templateUrl: './add-orders.component.html',
  styleUrls: ['./add-orders.component.css']
})

export class AddOrdersComponent implements OnInit {
  form: FormGroup;

  price: number;
  phone: string;
  address: string;
  idUser: string;
  idBook: string;

  public response: { 'dbPath': '' };
  orderAdd: Order = new Order;

  constructor(private fb: FormBuilder, public dialog: MatDialog, private httpservice: HttpService, public dialogRef: MatDialogRef<AddOrdersComponent>,
    @Inject(MAT_DIALOG_DATA) public id: number, private _snackBar: MatSnackBar) { }
  

  ngOnInit() {

    this.form = this.fb.group({
      price: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required],
      idUser: ['', Validators.required],
      idBook: ['', Validators.required]   

    });
  }

  onCancelar(): void {
    this.dialogRef.close();
  }

  onSubmit() {
    
    if (this.form.valid  ) {
      this.orderAdd.id = this.id;
      this.orderAdd.price = this.form.get('price').value;;
      this.orderAdd.phone = this.form.get('phone').value;;
      this.orderAdd.address = this.form.get('address').value;;
      this.orderAdd.idUser = this.form.get('idUser').value;;
      this.orderAdd.idBook = this.form.get('idBook').value;;
      this.httpservice.addOrder(this.orderAdd).subscribe(s => { 
        this.dialogRef.close({ data: s });
        this._snackBar.open("Creado Correctamente!!", "Aceptar", {
          duration: 2000
        });
      }, err => {
        this._snackBar.open("Error Al Crear", "Aceptar", {
          duration: 2000,
        });
      });
    }
    else {
        this._snackBar.open("Por Favor, ingrese los campos en rojo correctamente.", "Aceptar", {
          duration: 2000,
        });
    }
    window.location.reload();
  }
  public uploadFinished = (event) => {
    this.response = event;
  }
}
