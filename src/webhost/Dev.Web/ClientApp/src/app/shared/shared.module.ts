import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicHeaderComponent, ProtectedHeaderComponent } from '@/app/shared/components';
import { SessionStoreageService } from '@/app/shared/services';

@NgModule({
  declarations: [],
  imports: [
    CommonModule, 
    PublicHeaderComponent,
    ProtectedHeaderComponent,
  ],
  exports: [
    PublicHeaderComponent,
    ProtectedHeaderComponent
  ],
  providers: [
    SessionStoreageService
  ]
})
export class SharedModule { }
