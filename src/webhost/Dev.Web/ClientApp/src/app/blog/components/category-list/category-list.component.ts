import { Component } from '@angular/core';
import { CategoryService } from '@/app/blog/services';

@Component({
  selector: 'app-blog-category-list',
  standalone: true,
  imports: [],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.scss'
})
export class CategoryListComponent {
  constructor(private categoryService: CategoryService) { }
}
