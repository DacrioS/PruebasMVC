import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import "rxjs/Rx";
import 'rxjs/add/operator/toPromise';

import { ConfiguracionVM } from './configuracionVM';

@Injectable()
export class ConfigService {
    private headers = new Headers({'Content-Type': 'application/json'});
    private configsUrl = '../api/configuraciones';
    constructor(private http: Http) { }
    getConfigs(onNext: (json: any) => void) {
        this.http.get(this.configsUrl)
            .map(response => {
                let configs = new Array<ConfiguracionVM>();
                for (let obj of response.json()) {
                    configs[configs.length] = new ConfiguracionVM(
                        obj.ConfiguracionId, obj.Descripcion, obj.Valor);
                };
                return configs;
            })
            .subscribe(onNext);
    };
    getConfig(configId: number): Promise<ConfiguracionVM> {
        const url = `${this.configsUrl}/${configId}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                let obj = response.json();
                return new ConfiguracionVM(obj.ConfiguracionId, obj.Descripcion, obj.Valor);
            })
            .catch(this.handleError);
    };
    create(desc: string, val: string): Promise<ConfiguracionVM> {
        return this.http
            .post(this.configsUrl, JSON.stringify({descripcion: desc, valor: val}), {headers: this.headers})
            .toPromise()
            .then(response => {
                let obj = response.json();
                return new ConfiguracionVM(obj.ConfiguracionId, obj.Descripcion, obj.Valor);
            })
            .catch(this.handleError);
    };
    update(config: ConfiguracionVM): Promise<ConfiguracionVM> {
        const url = `${this.configsUrl}/${config.ConfiguracionId}`;
        return this.http
            .put(url, JSON.stringify(config), {headers: this.headers})
            .toPromise()
            .then(() => config)
            .catch(this.handleError);
    };
    delete(configId: number): Promise<void> {
        const url = `${this.configsUrl}/${configId}`;
        return this.http.delete(url, {headers: this.headers})
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    };
    private handleError(error: any): Promise<any> {
        console.error('Ha ocurrido un error', error); // for demo purposes only
        return Promise.reject(error.message || error);
    };
}