import { Injectable } from '@angular/core';
import { Http }       from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { ConfiguracionVM } from './configuracionVM';

@Injectable()
export class ConfigSearchService {
  constructor(private http: Http) {}
  search(term: string): Observable<ConfiguracionVM[]> {
      return this.http.get(`/api/configuraciones/?$filter=substringof('${term}',Descripcion)`)
        .map(response => {
            let configs = new Array<ConfiguracionVM>();
            for (let obj of response.json()) {
                configs[configs.length] = new ConfiguracionVM(
                    obj.ConfiguracionId, obj.Descripcion, obj.Valor);
            };
            return configs;
        });
  }
}
