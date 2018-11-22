import { Component, OnInit } from '@angular/core';
import { Router }            from '@angular/router';

import { Observable } from 'rxjs/Observable';
import { Subject }    from 'rxjs/Subject';
import 'rxjs/add/observable/of'; // Observable class extensions
import 'rxjs/add/operator/catch'; // Observable operators
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';

import { ConfigSearchService } from './config-search.service';
import { ConfiguracionVM } from './configuracionVM';

@Component({
  moduleId: module.id,
  selector: 'config-search',
  templateUrl: './Templates/config-search.component.html',
  styleUrls: [ './../../Content/config-search.component.css' ],
  providers: [ConfigSearchService]
})

export class ConfigSearchComponent implements OnInit {
  configs: Observable<ConfiguracionVM[]>;
  private searchTerms = new Subject<string>();
  constructor(
    private configSearchService: ConfigSearchService,
    private router: Router) {}
  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms.next(term);
  }
  ngOnInit(): void {
    this.configs = this.searchTerms
      .debounceTime(300)        // wait 300ms after each keystroke before considering the term
      .distinctUntilChanged()   // ignore if next search term is same as previous
      .switchMap(term => term   // switch to new observable each time the term changes
        // return the http search observable
        ? this.configSearchService.search(term)
        // or the observable of empty heroes if there was no search term
        : Observable.of<ConfiguracionVM[]>([]))
      .catch(error => {
        // TODO: add real error handling
        console.log(error);
        return Observable.of<ConfiguracionVM[]>([]);
      });
  }
  gotoDetail(config: ConfiguracionVM): void {
    let link = ['/detail', config.ConfiguracionId];
    this.router.navigate(link);
  }
}
