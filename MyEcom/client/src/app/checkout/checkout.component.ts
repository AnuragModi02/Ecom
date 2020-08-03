import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductselectedserviceService } from '../productselectedservice.service';
import { HttpClient } from '@angular/common/http';
import { combineLatest } from 'rxjs';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  productselected: any[] = [];
  products: any[] = [];
  displayedColumns: string[] = ['name', 'price', 'Quantity', 'Final Price'];
  @ViewChild('mattable') mattable: MatTable<any>;

  constructor(private productselectedserive: ProductselectedserviceService,private http: HttpClient) { }

  ngOnInit(): void {
    this.productselected = this.productselectedserive.productselect;
    for (let i = 0; i < this.productselected.length; i++)
    {
        this.http.get('https://localhost:44326/api/product/' + this.productselected[i].id).subscribe( data => {
        this.products.push(data);
        this.products[i].Quantity = this.productselected[i].quantity;
        this.products[i].finalprice = this.products[i].price * this.products[i].Quantity;
        console.log(this.products);
        this.mattable.renderRows();
      });
    }
  }

}
