import { Component, OnInit, ViewChild } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';
import { ProductselectedserviceService } from '../productselectedservice.service';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})

export class ProductComponent implements OnInit{

  products: any[];
  filterproducts: any[];
  producttype: any[];
  ProductTypeSelected: number;
  isActive: boolean = false;
  color: ThemePalette = 'warn';
  @ViewChild('button') button;
  noofitems: number = 0;
  productselect: any[] = [];

  constructor(private http: HttpClient, private route: Router, private productselectedserice: ProductselectedserviceService){

  }

  ngOnInit(): void {
    this.http.get('https://localhost:44326/api/product').subscribe((Response: any) => {
      this.products = Response;
      this.filterproducts = Response;
      console.log(this.products);
      this.button.focus();
      console.log(this.button);
    });

    this.http.get('https://localhost:44326/api/product/producttype').subscribe((producttype: any) => {
      this.producttype = producttype;
      console.log(this.producttype);
    });

  }

  selectproducttype(value: any): void {
    this.ProductTypeSelected = value;
    console.log('clicked');

    if (value === 0) {
    this.isActive = true;
    this.filterproducts = this.products;
    }
    else {
    this.isActive = false;
    this.filterproducts = this.products.filter(x =>
    {
      return x.productType.id === this.ProductTypeSelected;
    });
    }
  }

  Addtocart(productid: number, value: number): void{
    this.noofitems = this.noofitems + 1;
    console.log(productid);
    this.productselect.push({'id': productid, 'quantity': value});
    console.log(this.productselect);
  }
  Checkout(): void{
    this.productselectedserice.productselect = this.productselect;
    this.route.navigate(['checkout']);
  }
}
