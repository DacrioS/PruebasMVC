import { Component } from '@angular/core';
import { OnInit }    from '@angular/core';
import { Router }    from '@angular/router';

import { ConfiguracionVM } from './configuracionVM';
import { ConfigService }   from './config.service';

@Component({
  moduleId: module.id,
  selector: 'my-configs',
  templateUrl: './Templates/config.component.html',
  styleUrls: [ './../../Content/config.component.css' ]
})

export class ConfigComponent implements OnInit {
  constructor(private configService: ConfigService, private router: Router) { };
  configs: ConfiguracionVM[];
  selectedConfig: ConfiguracionVM;
  onSelect(cfg: ConfiguracionVM): void {
    this.selectedConfig = cfg;
  };
  //getConfigs(): void {
  //  this.configService.getConfigs().then(configs => this.configs = configs);
  //};
  getConfigs(): void {
      this.configService.getConfigs(configs => this.configs = configs);
  };
  ngOnInit(): void {
    this.getConfigs();
  };
  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedConfig.ConfiguracionId]);
  };
  add(desc: string, val: string): void {
    desc = desc.trim();
    val = val.trim();
    if (!desc) { return; }
    this.configService.create(desc, val)
      .then(config => {
        this.configs.push(config);
        this.selectedConfig = null;
      });
  };
  delete(config: ConfiguracionVM): void {
    this.configService
        .delete(config.ConfiguracionId)
        .then(() => {
          this.configs = this.configs.filter(c => c !== config);
          if (this.selectedConfig === config) { this.selectedConfig = null; }
        });
  };
}
