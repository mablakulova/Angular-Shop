import { NgModule } from "@angular/core";
import { FlexLayoutModule } from "@angular/flex-layout";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "src/app/app-routing.module";
import { SharedModule } from "src/app/shared/shared.module";
import { NavBarComponent } from "./nav-bar.component";

@NgModule({
    declarations: [NavBarComponent],
    imports: [BrowserAnimationsModule,FlexLayoutModule, SharedModule, AppRoutingModule],
    exports: [NavBarComponent]
  })
  export class NavBarModule {}