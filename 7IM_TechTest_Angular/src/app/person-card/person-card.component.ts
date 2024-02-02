import { Component, Input } from '@angular/core';
import { Person } from '../Person';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrl: './person-card.component.css'
})
export class PersonCardComponent {
  @Input() person: Person | null = null;
}
