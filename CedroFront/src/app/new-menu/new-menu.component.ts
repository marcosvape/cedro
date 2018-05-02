import { Component, OnInit } from '@angular/core';
import { MenuServiceService } from '../menu-service.service';
import { RestaurantServiceService } from '../restaurant-service.service';
import { Menu } from '../menu';
import { Restaurant } from '../restaurant';
import {Router} from '@angular/router';

@Component({
  selector: 'app-new-menu',
  templateUrl: './new-menu.component.html',
  styleUrls: ['./new-menu.component.css']
})

export class NewMenuComponent implements OnInit {
  menu: Menu;
  restaurants: Restaurant[];

  constructor(private menuService: MenuServiceService, private restaurantService: RestaurantServiceService, private router: Router) { 
  	this.menu = new Menu();
  	 this.restaurantService.getRestaurants()
        .subscribe(restaurants => { 
            this.restaurants = restaurants;
        });
  }

  ngOnInit() {
  }

  onSubmit() { 
  	this.menuService.createMenu(this.menu);
    this.router.navigateByUrl('/menus');
  }

}
