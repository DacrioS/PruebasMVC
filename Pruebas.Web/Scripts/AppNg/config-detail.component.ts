import { Component, OnInit }      from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location }               from '@angular/common';

import 'rxjs/add/operator/switchMap'; //Se utiliza en OnInit para mapear los párametros URL

import { ConfiguracionVM } from './configuracionVM';
import { ConfigService }   from './config.service';

@Component({
  moduleId: module.id,
  selector: 'config-detail',
  templateUrl: './Templates/config-detail.component.html',
  styleUrls: [ './../../Content/config-detail.component.css' ]
})

export class ConfigDetailComponent implements OnInit {
  config: ConfiguracionVM;
  constructor(
    private configService: ConfigService,
    private route: ActivatedRoute,
    private location: Location
  ) {};
  ngOnInit(): void {
    this.route.params
      //Se utiliza el operador + para hacer un cast rápidamente de string a number
      .switchMap((params: Params) => this.configService.getConfig(+params['id']))
      .subscribe(config => this.config = config);
  };
  save(): void {
    this.configService.update(this.config)
      .then(() => this.goBack());
  };
  goBack(): void {
    this.location.back();
  };
}