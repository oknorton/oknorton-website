import { Component, HostListener, ElementRef, ViewChild } from '@angular/core';
import {ScrollService} from "../../Services/scroll.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  constructor(private scrollService: ScrollService) { }

  private readonly PADDING_CLASS = 'p-6';
  private readonly CORNER_CLASS  = 'rounded';

  @ViewChild('navbar') navbarRef!: ElementRef;
  @ViewChild('corner') cornerRef!: ElementRef;

  scrollToElement(id: string): void {
    this.scrollService.scrollToElement(id);
  }


  @HostListener("window:scroll", [])
  onWindowScroll() {
    if (window.pageYOffset > 0) {
      this.togglePadding(true);
      this.toggleRoundedCorners(true);
    } else {
      this.togglePadding(false);
      this.toggleRoundedCorners(false);
    }

  }

  private togglePadding(addPadding: boolean): void {
    const classList = this.navbarRef.nativeElement.classList;

    if (addPadding) {
      classList.add(this.PADDING_CLASS);
    } else {
      classList.remove(this.PADDING_CLASS);
    }
  }

  private toggleRoundedCorners(addRoundedCorners: boolean): void {
    const classList = this.cornerRef.nativeElement.classList;

    if (addRoundedCorners) {
      classList.add(this.CORNER_CLASS);
    } else {
      classList.remove(this.CORNER_CLASS);
    }
  }
}
