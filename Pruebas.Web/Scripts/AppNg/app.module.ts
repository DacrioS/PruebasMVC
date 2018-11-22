import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { AppRoutingModule }      from './app-routing.module';

// Imports for loading & configuring the in-memory web api
//import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService }  from './in-memory-data.service';

import { AppComponent }          from './app.component';
import { ConfigDetailComponent } from './config-detail.component';
import { DashboardComponent }    from './dashboard.component';
import { ConfigComponent }       from './config.component';
import { ConfigSearchComponent } from './config-search.component';
import { ConfigService }         from './config.service';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule,
        /*InMemoryWebApiModule.forRoot(InMemoryDataService),*/ AppRoutingModule],
    declarations: [AppComponent, DashboardComponent, ConfigDetailComponent,
        ConfigComponent, ConfigSearchComponent],
    providers: [ConfigService],
    bootstrap: [AppComponent]
})

export class AppModule { }
