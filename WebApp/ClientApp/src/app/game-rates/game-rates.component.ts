import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'game-rates',
  templateUrl: './game-rates.component.html',
  styleUrls: ['./game-rates.component.css']
})
export class GameRatesComponent {
  public gameRates: GameRate[];
  private isAuthenticated: boolean;
  http: HttpClient;
  baseUrl: string;
  isUserRatesLoaded: boolean;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, authorizeService: AuthorizeService) {
    this.baseUrl = baseUrl;
    authorizeService.isAuthenticated().subscribe({ next: isAuth => this.isAuthenticated = isAuth });
    this.http = http;
    this.loadAllRating();
  }

  loadAllRating() {
    this.http.get<GameRate[]>(this.baseUrl + 'GameRater/GetAllGameRates').subscribe(result => {
      this.gameRates = result;
      this.isUserRatesLoaded = false;
    }, error => console.error(error));
  }

  public saveUserRate(gameId: Number, event: Number) {
    this.http.post<void>(this.baseUrl + 'GameRater/SaveGameRate', { gameId: gameId, userRate: event }).subscribe(() => {
      if (!this.isUserRatesLoaded) {
        this.loadAllRating();
      }
    }, error => console.error(error));
  }

  public loadUserRatings() {
    this.http.get<GameRate[]>(this.baseUrl + 'GameRater/GetUserGameRates').subscribe(result => {
      this.gameRates = result;
      this.isUserRatesLoaded = true;
    }, error => console.error(error));
  }
}

export class GameRate {
  gameId: number;
  title: string;
  releaseDate: string;
  releaser: string;
  avgRating: number;
}
