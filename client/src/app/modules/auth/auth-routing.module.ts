import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { UnauthorizedComponent } from "./unauthorized/unauthorized.component";

export const routes: Routes = [
    { path: 'unauthorized', component: UnauthorizedComponent },
    { path: 'login', component: LoginComponent },
  ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })

export class AuthRoutingModule  {}