import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlogRoutingModule } from '@/app/blog/blog-routing.module';
import { CategoryService } from '@/app/blog/services/category.service';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BlogRoutingModule
  ],
  providers: [CategoryService]
})
export class BlogModule { }
