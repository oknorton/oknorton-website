import { Component } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Inject } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  activeSection = 1;
  constructor(
    @Inject(DOCUMENT) private document: any
  ) {}

}
