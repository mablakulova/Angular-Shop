import { Component } from '@angular/core';
import { TranslocoService } from '@ngneat/transloco';
import { User } from 'src/app/core/models/user';
import { AuthenticationService } from 'src/app/core/service/authentication.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent {
  pageTitle = 'Angular Shop';
  color = 'cyan';
  user: User;
  siteLanguage = 'English';

  languageList = [
    { code: 'en', label: 'English' },
    { code: 'ru', label: 'Russian' },
  ];

  constructor(
    private authenticationService: AuthenticationService,
    private translocoService: TranslocoService,
  ) {
    this.authenticationService.user.subscribe((x) => (this.user = x));
  }

  logout() {
    this.authenticationService.logout();
  }

  changeSiteLanguage(language: string): void {
    this.translocoService.setActiveLang(language);
    this.siteLanguage = this.languageList.find((f) => f.code === language).label;
  }
}
