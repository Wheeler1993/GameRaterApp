import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'game-rates',
  templateUrl: './game-rates.component.html',
  styleUrls: ['./game-rates.component.css']
})
export class GameRatesComponent {
  public allLoadedGameRates: GameRate[];
  public gameRatesOfCurrentPage: GameRate[];
  private isAuthenticated: boolean;
  http: HttpClient;
  route: ActivatedRoute
  baseUrl: string;
  isMyRates: boolean;
  releaserId: number;
  numberOfLoadedRates: number;
  pageSize: number;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, authorizeService: AuthorizeService, route: ActivatedRoute) {
    this.baseUrl = baseUrl;
    authorizeService.isAuthenticated().subscribe({ next: isAuth => this.isAuthenticated = isAuth });
    this.http = http;
    this.route = route;
  }

  ngOnInit() {
    let releaserId = parseInt(this.route.snapshot.paramMap.get('releaserId'));
    let isMyRating = this.route.snapshot.data.isMyRating;
    
    if (releaserId) {
      this.loadRatingsByReleaser(releaserId);
      this.releaserId = releaserId;
    }
    else if (isMyRating) {
      this.loadUserRatings();
      this.isMyRates = true;
    }
    else {
      this.loadAllRating();
    }
  }

  public pageChange(page: number) {
    let skip = (page - 1) * this.pageSize;
    let take = page * this.pageSize
    this.gameRatesOfCurrentPage = this.allLoadedGameRates.slice(skip, take);
  }

  InitializeVariables(result: GameRate[]) {
    this.http.get<number>(this.baseUrl + 'GameRater/GetPageSize').subscribe(pageSize => {
      this.pageSize = pageSize;
      this.allLoadedGameRates = result;
      this.numberOfLoadedRates = result.length;
      this.pageChange(1);
    })
  }

  loadAllRating() {
    this.http.get<GameRate[]>(this.baseUrl + 'GameRater/GetAllGameRates').subscribe(result => {
      this.InitializeVariables(result);
    }, error => console.error(error));
  }

  public saveUserRate(gameId: Number, event: Number) {
    this.http.post<void>(this.baseUrl + 'GameRater/SaveGameRate', { gameId: gameId, userRate: event }).subscribe(() => {
      if (!this.isMyRates) {
        this.loadAllRating();
      }
    }, error => console.error(error));
  }

  public loadUserRatings() {
    this.http.get<GameRate[]>(this.baseUrl + 'GameRater/GetUserGameRates').subscribe(result => {
      this.InitializeVariables(result);
    }, error => console.error(error));
  }

  public loadRatingsByReleaser(releaserId: number) {
    this.http.get<GameRate[]>(this.baseUrl + 'GameRater/GetGameRatesByReleaser?releaserId=' + releaserId).subscribe(result => {
      this.InitializeVariables(result);
    }, error => console.error(error));
  }
}

export class GameRate {
  gameId: number;
  title: string;
  releaseDate: string;
  releaser: string;
  releaserId: number;
  cover: string;
  avgRating: number;
}
