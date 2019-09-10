import { MecanicListComponent } from './components/mecanic-list/mecanic-list.component';
import { MecanicService } from './services/mecanic.service';
import { MecanicViewComponent } from './components/mecanic-view/mecanic-view.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ng6-toastr-notifications';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MecanicViewComponent,
    MecanicListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpModule,
    RouterModule.forRoot([
      { path: 'mecanicos', component: MecanicViewComponent, pathMatch: 'full' },
      { path: 'mecanicos/:doc/:tipoDoc', component: MecanicViewComponent},
      { path: 'mecanicos/list', component: MecanicListComponent},
      { path: '', component: MecanicListComponent}
    ])
  ],
  providers: [MecanicService],
  bootstrap: [AppComponent]
})
export class AppModule { }
