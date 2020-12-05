import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { PagingHeaderComponent } from '../shared/components/paging-header/paging-header.component';
import { ProductDetailsComponent } from './product-details/product-details.component';



@NgModule({
  declarations: [ShopComponent, ProductItemComponent, ProductDetailsComponent],
  imports: [
    SharedModule,
    CommonModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
