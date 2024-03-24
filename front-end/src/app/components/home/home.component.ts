import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';
// @ts-ignore
import Typewriter from 'typewriter-effect/dist/core';
import {ScrollService} from "../../Services/scroll.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {
  @ViewChild('home') homeRef!: ElementRef;
  @ViewChild('about') aboutMeRef!: ElementRef;
  @ViewChild('project') projectRef!: ElementRef;
  @ViewChild('github') githubRef!: ElementRef;
  @ViewChild('experience') experienceRef!: ElementRef;
  @ViewChild('contact') contactRef!: ElementRef;
  constructor(private elementRef: ElementRef, private scrollService: ScrollService) {}

  ngAfterViewInit() {
    this.scrollService.setElement('home', this.homeRef.nativeElement);
    this.scrollService.setElement('about', this.aboutMeRef.nativeElement);
    this.scrollService.setElement('project', this.projectRef.nativeElement);
    this.scrollService.setElement('experience', this.experienceRef.nativeElement);
    this.scrollService.setElement('contact', this.contactRef.nativeElement);
    this.scrollService.setElement('github', this.githubRef.nativeElement);

    const targetElement = this.elementRef.nativeElement.querySelector('.typewriter');

    const typewriter: any = new Typewriter(targetElement, {
      loop: true,
      delay: 75
    });

    const words: string[] = ['Computer Science', 'Artificial intelligence', '3D simulation', '2D graphics', 'Web Development', 'Embedded Systems', 'Virtual Reality',   'Android Development', 'Project Architecture', 'System Design', 'Agile Workmethods'];

    for (const word of words) {
      typewriter.typeString(word)
        .pauseFor(1000)
        .deleteAll();
    }

    typewriter.start();
  }
}
