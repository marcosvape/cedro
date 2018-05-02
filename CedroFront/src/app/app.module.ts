import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { AppComponent } from './app.component';
import { RestaurantTableComponent } from './restaurant-table/restaurant-table.component';
import { RestaurantsComponent } from './restaurants/restaurants.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RouterModule, Routes } from '@angular/router';
import { MenusComponent } from './menus/menus.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { NewRestaurantComponent } from './new-restaurant/new-restaurant.component';
import { NewMenuComponent } from './new-menu/new-menu.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { MenuTableComponent } from './menu-table/menu-table.component';

import { RestaurantServiceService } from './restaurant-service.service';
import { MenuServiceService } from './menu-service.service';

import { HttpModule } from '@angular/http';

const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'menus',  component: MenusComponent },
  { path: 'menu/:id', component: MenuComponent },
  { path: 'menu', component: NewMenuComponent },
  { path: 'restaurants', component: RestaurantsComponent },
  { path: 'restaurant/:id', component: RestaurantComponent },
  { path: 'restaurant', component: NewRestaurantComponent },
  { path: '', redirectTo: '/home',  pathMatch: 'full' },
  { path: '**', redirectTo: '/home',  pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    RestaurantTableComponent,
    RestaurantsComponent,
    RestaurantComponent,
    MenusComponent,
    MenuComponent,
    HomeComponent,
    NewRestaurantComponent,
    NewMenuComponent,
    MenuTableComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(
      appRoutes
    )
  ],
  providers: [
    RestaurantServiceService,
    MenuServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
