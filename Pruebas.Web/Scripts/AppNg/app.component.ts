import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'config-app',
    template: `
    <h1>{{title}}</h1>
    <nav>
        <a routerLink="/dashboard" routerLinkActive="active">Panel</a>
        <a routerLink="/configs" routerLinkActive="active">Listado</a>
    </nav>
    <router-outlet></router-outlet>`,
    styleUrls: ['./../../Content/app.component.css']
})

export class AppComponent {
    title = 'Pruebas Angular v2';
}