import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ScrollService {
  private elements: Map<string, HTMLElement> = new Map<string, HTMLElement>();

  setElement(id: string, element: HTMLElement): void {
    this.elements.set(id, element);
  }

  scrollToElement(id: string): void {
    this.elements.get(id)?.scrollIntoView({ behavior: 'smooth' });
  }
}
