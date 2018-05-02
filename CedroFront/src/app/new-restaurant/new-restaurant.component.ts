import { Component, OnInit } from '@angular/core';
import { RestaurantServiceService } from '../restaurant-service.service';
import { Restaurant } from '../restaurant';
import {Router} from '@angular/router';

@Component({
  selector: 'app-new-restaurant',
  templateUrl: './new-restaurant.component.html',
  styleUrls: ['./new-restaurant.component.css']
})
export class NewRestaurantComponent implements OnInit {
  restaurant: Restaurant;

  constructor(private restaurantService: RestaurantServiceService, private router: Router) { 
  	this.restaurant = new Restaurant();
  }

  ngOnInit() {
  }

  onSubmit() { 
  	this.restaurantService.createRestaurant(this.restaurant);
    this.router.navigateByUrl('/restaurants');
  }

}
