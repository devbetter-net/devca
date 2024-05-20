import { Component } from '@angular/core';
import { SessionStoreageService } from '@/app/shared/services/session-storeage.service';

@Component({
  selector: 'app-shared-protected-header',
  standalone: true,
  imports: [],
  templateUrl: './protected-header.component.html',
  styleUrl: './protected-header.component.scss'
})
export class ProtectedHeaderComponent {
  constructor(private sessionStoreageService: SessionStoreageService
  ) { }
  logout() {
    this.sessionStoreageService.clearToken();
    location.reload();
  }
}
