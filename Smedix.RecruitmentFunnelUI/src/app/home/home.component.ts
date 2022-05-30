import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  constructor() { }

  dictionary: { [key: number]: string } = {
    1: 'daphne',
    2: 'simon',
    3: 'sharma',
    4: 'anthony',
    5: 'eloise',
  };

  ngOnInit(): void {
  }
  
}
