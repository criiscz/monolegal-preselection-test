import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './invoice-container.component.html'
})
export class InvoiceContainerComponent {
  public invoices: Invoice[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<Invoice[]>(baseUrl + 'api/invoice').subscribe(result => {
      this.invoices = result;
    }, error => console.error(error));

  }


}