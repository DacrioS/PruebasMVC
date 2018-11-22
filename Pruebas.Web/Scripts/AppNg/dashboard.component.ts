import { Component, OnInit } from '@angular/core';

import { ConfiguracionVM } from './configuracionVM';
import { ConfigService }   from './config.service';

@Component({
  moduleId: module.id,
  selector: 'my-dashboard',
  templateUrl: './Templates/dashboard.component.html',
  styleUrls: [ './../../Content/dashboard.component.css' ]

})

export class DashboardComponent implements OnInit {
  configs: ConfiguracionVM[] = [];
  constructor(private configService: ConfigService) { }
  ngOnInit(): void {
    this.configService.getConfigs(configs =>
        this.configs = configs ? configs.slice(-4) : configs);
  }
}