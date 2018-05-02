import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Restaurant } from './restaurant';

@Injectable()
export class RestaurantServiceService {

  	private apiURL = 'http://192.168.0.16:65000/api/restaurant/';
    private options: any;

  	constructor(private http: Http) {
     let head = new Headers({ 'Content-Type': 'application/json' });
     this.options = new RequestOptions({ headers: head });
  	}

    getRestaurants(): Observable<Restaurant[]> {
    return this.http.get(this.apiURL) 
        .map(res => { 
          return res.json().map(item => {
            return item;
          });
        });
    }

  getRestaurant(restaurantId): Observable<Restaurant> {
    return this.http.get(this.apiURL + restaurantId) 
        .map(res => { 
          return res.json();
        });
    }

  createRestaurant(restaurant) {

    this.http.post(this.apiURL, restaurant, this.options).subscribe();
    }

  updateRestaurant(restaurant) {
      
     this.http.put(this.apiURL + restaurant.id, restaurant, this.options).subscribe();
    }

  deleteRestaurant(restaurantId) {
     this.http.delete(this.apiURL + restaurantId).subscribe();
    }

}