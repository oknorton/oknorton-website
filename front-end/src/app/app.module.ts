import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatMenuModule} from "@angular/material/menu";
import {MatButtonModule} from "@angular/material/button";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatSidenavModule} from "@angular/material/sidenav";
import {RouterLink, RouterOutlet} from "@angular/router";
import {MatDividerModule} from "@angular/material/divider";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {AppRoutingModule} from "./app-routing.module";
import {CommonModule} from "@angular/common";
import {HomeComponent} from "./components/home/home.component";
import { NavbarComponent } from './components/navbar/navbar.component';
import { AboutMeComponent } from './components/home/about-me/about-me.component';
import { SocialIconsComponent } from './components/home/about-me/social-icons/social-icons.component';
import { SvgCarouselComponent } from './components/home/svg-carousel/svg-carousel.component';
import { ProjectListComponent } from './components/home/project-list/project-list.component';
import { HttpClientModule } from '@angular/common/http';
import { GithubComponent } from './components/github/github.component';
import {FormsModule} from "@angular/forms";
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    NavbarComponent,
    AboutMeComponent,
    SocialIconsComponent,
    SvgCarouselComponent,
    ProjectListComponent,
    GithubComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatMenuModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    RouterOutlet,
    MatDividerModule,
    RouterLink,
    MatDatepickerModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
