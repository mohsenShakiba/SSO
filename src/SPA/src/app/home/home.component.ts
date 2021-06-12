import {Component, OnInit} from '@angular/core';
import {ApiService} from "../core/api.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  isFetching = true;
  isAuthenticated = false;

  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
    this.apiService.isUserAuthenticated().subscribe(r => {
      this.isFetching = false;
      this.isAuthenticated = r;
    });
  }

}
