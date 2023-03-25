import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AdmindashboardComponent } from './components/admindashboard/admindashboard.component';
import { AddComponent } from './components/course/add/add.component';
import { UpdateComponent } from './components/course/update/update.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EditComponent } from './components/edit/edit.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterrComponent } from './components/registerr/registerr.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"registerr",component:RegisterrComponent},
  {path:"logout",component:LogoutComponent},
  {path:"dashboard",component:DashboardComponent},
  {path:"admindashboard",component:AdmindashboardComponent,canActivate:[AuthGuard]},
  {path:"admindashboard/editUser/:id",component:EditComponent},
  {path:"dashboard/editCourse/:id",component:UpdateComponent},
  {path:"dashboard/add",component:AddComponent},
  {path:"Add",component:AddComponent},
  {path:"edit",component:EditComponent},
  {path:"update",component:UpdateComponent},
  {path:"user-dashboard",component:UserDashboardComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
