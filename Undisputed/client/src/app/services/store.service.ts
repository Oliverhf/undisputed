import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable()
export class Store {

    constructor(private http: HttpClient) {

    }


    public products = [];

    loadProducts() {
        return this.http.get<[]>("/api/shop/products")
            .pipe(map(data => {
                this.products = data;
                return;
            }));
    }
}