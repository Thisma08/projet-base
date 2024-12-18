import {Component, OnDestroy, OnInit} from '@angular/core';
import {Theme} from '../themes/theme';
import {ThemeService} from '../../shared/services/theme/theme.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  themes: Theme[] = [];

  constructor(private themeService: ThemeService) {}

  ngOnInit(): void {
    this.loadThemes();
  }

  loadThemes():void {
    this.themeService.getAllThemes().subscribe((data: Theme[]) => {
      this.themes = data;
    })
  }
}
