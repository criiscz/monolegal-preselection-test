import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {InvoiceCardComponent} from "./invoice-container/invoice-card/invoice-card.component";
import {
  InvoiceContainerComponent
} from "./invoice-container/invoice-container.component";

@NgModule({
  declarations: [
    AppComponent,
    InvoiceCardComponent,
    InvoiceContainerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', component: HomeComponent, pathMatch: 'full' },
      {path: '', component: InvoiceContainerComponent, pathMatch: 'full'},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
