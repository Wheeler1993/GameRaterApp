import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './editable-rates.component.html'
})
export class EditableRatesComponent {
  public gameRates: GameRate[];
  private isAuthenticated: boolean;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, authorizeService: AuthorizeService) {
    authorizeService.isAuthenticated().subscribe({ next: isAuth => this.isAuthenticated = isAuth });
    http.get<GameRate[]>(baseUrl + 'GameRater/gamerates').subscribe(result => {
      debugger;
      this.gameRates = result;
    }, error => console.error(error));
  }
}

interface GameRate {
  title: string;
  releaseDate: string;
  releaser: string;
  avgRating: number;
}
