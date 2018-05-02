import { Component, OnInit } from '@angular/core';
import { Router  , ActivatedRoute } from '@angular/router';
import { RestaurantServiceService } from '../restaurant-service.service';
import { Restaurant } from '../restaurant';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  restaurant: Restaurant;

  constructor(private activeRoute: ActivatedRoute, private restaurantService: RestaurantServiceService, private router: Router) {
      this.restaurant = new Restaurant();
   }

  ngOnInit() {
    	 this.restaurantService.getRestaurant(this.activeRoute.snapshot.params['id'])
        .subscribe(restaurant => { 
            this.restaurant = restaurant;
        });
  }

  onSubmit() { 
    this.restaurantService.updateRestaurant(this.restaurant);
    this.router.navigateByUrl('/restaurants');
   }

}