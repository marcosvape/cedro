import { Component, OnInit } from '@angular/core';
import { RestaurantServiceService } from '../restaurant-service.service';
import { Restaurant } from '../restaurant';

@Component({
  selector: 'app-restaurant-table',
  templateUrl: './restaurant-table.component.html',
  styleUrls: ['./restaurant-table.component.css']
})

export class RestaurantTableComponent implements OnInit {

	restaurants: Restaurant[];

  	constructor(private restaurantService: RestaurantServiceService) { }

  	ngOnInit() {

  	 this.restaurantService.getRestaurants()
        .subscribe(restaurants => { 
            this.restaurants = restaurants; 
        });
  	}

  public deleteRestaurant(restaurantId) {
    this.restaurantService.deleteRestaurant(restaurantId);
    window.location.reload();
  }


}