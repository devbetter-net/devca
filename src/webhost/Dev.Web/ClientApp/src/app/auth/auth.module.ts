import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from '@/app/auth/services/auth.service';
import { SharedModule } from '@/app/shared/shared.module';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthRoutingModule,
    SharedModule
  ],
  providers: [AuthService]
})
export class AuthModule { }
