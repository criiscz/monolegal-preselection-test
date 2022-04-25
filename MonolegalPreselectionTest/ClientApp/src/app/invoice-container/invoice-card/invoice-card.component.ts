import {Component, Input} from "@angular/core";

@Component({
  selector: 'invoice-card',
  templateUrl: './invoice-card.component.html',
  styleUrls: ['./invoice-card.component.css']
})
export class InvoiceCardComponent {
  @Input() invoice: Invoice = null!;

  getInvoiceStatus() {
    if (this.invoice)
      return this.invoice.Pagada ? "PAGADA" : "SIN PAGAR";
    else return "";
  }

  getCreationDate() {
    if (this.invoice) {
      const date = new Date(this.invoice.FechaCreacion);
      return date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes();
    } else return "";
  }

  getPaidDate() {
    if (this.invoice) {
      const date = new Date(this.invoice.FechaPago);
      return date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes();
    } else return "";
  }

  getInvoiceState() {
    if (this.invoice)
      return this.invoice.Estado == "primerRecordatorio" ? "Primer recordatorio"
        : this.invoice.Estado == "segundoRecordatorio" ? "Segundo recordatorio"
          : this.invoice.Estado == "desactivada" ? "Desactivada" : "";
    else return "";
  }
}

