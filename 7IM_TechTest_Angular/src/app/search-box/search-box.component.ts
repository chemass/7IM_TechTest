import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule, ValidationErrors } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrl: './search-box.component.css',
  imports: [
    CommonModule,
    FormsModule
  ]
})

export class SearchBoxComponent {
  @Output() doSearch = new EventEmitter<string>();

  public searchText: string = "";

  btnClick(value: string) {
    this.doSearch.emit(value);
  }

  getErrors(arg: ValidationErrors | null) {
    if (arg == null)
      return;

    if (arg['required'])
      return ['This field cannot be empty.'];

    let output: String[] = [];
    let i = 0;
    for (let key in Object.keys(arg)) {
      output[i++] = arg[key];
    }

    return output;
  }
}
