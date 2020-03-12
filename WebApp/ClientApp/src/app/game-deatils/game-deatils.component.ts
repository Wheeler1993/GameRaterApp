import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { GameRate } from '../game-rates/game-rates.component';

@Component({
  selector: 'app-game-deatils',
  templateUrl: './game-deatils.component.html',
  styleUrls: ['./game-deatils.component.css']
})
export class GameDeatilsComponent implements OnInit {
  route: ActivatedRoute;
  http: HttpClient;
  game: GameRateWithDetails;
  baseUrl: string;

  constructor(route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.route = route;
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    let gameId = this.route.snapshot.paramMap.get('gameId');
    this.loadRatingWithDetail(gameId);
  }

  public loadRatingWithDetail(gameId: string) {
    this.http.get<GameRateWithDetails>(this.baseUrl + 'GameRater/GetGameRateWithDetails?gameId=' + gameId).subscribe(result => {
      this.game = result;
    }, error => console.error(error));
  }

  public saveUserRate(gameId: Number, event: Number) {
    this.http.post<void>(this.baseUrl + 'GameRater/SaveGameRate', { gameId: gameId, userRate: event }).subscribe(() => {
      this.loadRatingWithDetail(gameId.toString());
    }, error => console.error(error));
  }

}

class GameRateWithDetails extends GameRate {
  details: string;
}
