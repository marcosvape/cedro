import { Component, OnInit } from '@angular/core';
import { MenuServiceService } from '../menu-service.service';
import { Menu } from '../menu';

@Component({
  selector: 'app-menu-table',
  templateUrl: './menu-table.component.html',
  styleUrls: ['./menu-table.component.css']
})

export class MenuTableComponent implements OnInit {

	menus: Menu[];

  	constructor(private menuService: MenuServiceService) { }

  	ngOnInit() {

  	 this.menuService.getMenus()
        .subscribe(menus => { 
            this.menus = menus; 
        });
  	}

  public deleteMenu(menuId) {
    this.menuService.deleteMenu(menuId);
    window.location.reload();
  }

}