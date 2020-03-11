import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDeatilsComponent } from './game-deatils.component';

describe('GameDeatilsComponent', () => {
  let component: GameDeatilsComponent;
  let fixture: ComponentFixture<GameDeatilsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameDeatilsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDeatilsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
