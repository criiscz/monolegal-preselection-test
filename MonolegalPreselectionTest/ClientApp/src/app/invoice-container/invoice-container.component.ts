import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './invoice-container.component.html',
  styleUrls: ['./invoice-container.component.css']
})
export class InvoiceContainerComponent {
  public invoices: Invoice[] = [];
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.getInvoices();
  }

  getInvoices() {
    this.http.get<Invoice[]>(this.baseUrl + 'api/invoice').subscribe(result => {
      this.invoices = result;
      this.invoices.sort((invoiceA, invoiceB) => invoiceA.Cliente.localeCompare(invoiceB.Cliente))
    }, error => console.error(error));
  }

  async updateInvoices() {
    document.getElementsByClassName('toast')[0].classList.add('show');
    document.getElementsByClassName('toast-header')[0].classList.add('updating');
    document.getElementsByClassName('text-invoice')[0].innerHTML = 'Actualizando facturas...';
    this.http.post(this.baseUrl + 'api/invoice/update', "{}").subscribe(async () => {
      this.getInvoices();
    }, error => console.error(error), () => {
      document.getElementsByClassName('toast-header')[0].classList.remove('updating');
      document.getElementsByClassName('text-invoice')[0].innerHTML = 'Facturas actualizadas';
      setTimeout(() => {
        document.getElementsByClassName('toast')[0].classList.remove('show');
      }, 4000);
    });


  }


}