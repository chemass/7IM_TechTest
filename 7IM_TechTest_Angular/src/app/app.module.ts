import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchBoxComponent } from './search-box/search-box.component';
import { PersonCardComponent } from './person-card/person-card.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonCardComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    SearchBoxComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
