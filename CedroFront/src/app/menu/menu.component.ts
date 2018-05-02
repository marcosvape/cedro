import { Component, OnInit } from '@angular/core';
import { Router  , ActivatedRoute } from '@angular/router';
import { MenuServiceService } from '../menu-service.service';
import { Menu } from '../menu';
import { RestaurantServiceService } from '../restaurant-service.service';
import { Restaurant } from '../restaurant';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})

export class MenuComponent implements OnInit {
  menu: Menu;
  restaurants: Restaurant[];

  constructor(private activeRoute: ActivatedRoute, private menuService: MenuServiceService, private restaurantService: RestaurantServiceService, private router: Router) { 
    this.menu = new Menu();
  }

  ngOnInit() {
    	 this.restaurantService.getRestaurants()
        .subscribe(restaurants => { 
            this.restaurants = restaurants;
        });

		this.menuService.getMenu(this.activeRoute.snapshot.params['id'])
        .subscribe(menu => { 
            this.menu = menu;
        });
  }

  onSubmit() { 
    this.menuService.updateMenu(this.menu);
    this.router.navigateByUrl('/menus');
   }

}