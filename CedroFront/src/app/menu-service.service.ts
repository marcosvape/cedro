import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Menu } from './menu';

@Injectable()
export class MenuServiceService {

  	private apiURL = 'http://192.168.0.16:65000/api/menu/';
    private options: any;

  	constructor(private http: Http) {
      let head = new Headers({ 'Content-Type': 'application/json' });
     this.options = new RequestOptions({ headers: head });
  	}

	getMenus(): Observable<Menu[]> {
    return this.http.get(this.apiURL) 
        .map(res => { 
          return res.json().map(item => {
            return item;
          });
        });
    }

  getMenu(menuId): Observable<Menu> {
    return this.http.get(this.apiURL + menuId) 
        .map(res => { 
          return res.json();
        });
    }

    createMenu(menu) {
       this.http.post(this.apiURL, menu, this.options).subscribe();
    }

  updateMenu(menu) {

    this.http.put(this.apiURL + menu.id, menu, this.options).subscribe();
    }

  deleteMenu(menuId) {
     this.http.delete(this.apiURL + menuId).subscribe();
    }

}