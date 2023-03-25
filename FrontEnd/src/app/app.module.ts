import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AddCourseComponent } from './components/Courses/add-course/add-course.component';
import { DeleteCourseComponent } from './components/Courses/delete-course/delete-course.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddourseComponent } from './components/Courses/addourse/addourse.component';
import { AddcourseComponent } from './components/Courses/addcourse/addcourse.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/nav/nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { HeaderComponent } from './components/header/header.component';
import { RegisterrComponent } from './components/registerr/registerr.component';

import {MatExpansionModule} from '@angular/material/expansion';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LogoutComponent } from './components/logout/logout.component';
import { EditComponent } from './components/edit/edit.component';
import { AdmindashboardComponent } from './components/admindashboard/admindashboard.component';

import { AddComponent } from './components/course/add/add.component';
import { UpdateComponent } from './components/course/update/update.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { AddtocartComponent } from './components/addtocart/addtocart.component';
import {MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent,
    RegisterrComponent,
    LoginComponent,
    AddCourseComponent,
    DeleteCourseComponent,
    DashboardComponent,
    AddourseComponent,
    AddcourseComponent,
    NavComponent,
    HeaderComponent,
    LogoutComponent,
    EditComponent,
    AdmindashboardComponent,
    UpdateComponent,
    AddComponent,
    UserDashboardComponent,
    AddtocartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatExpansionModule,
     MatFormFieldModule,
     FormsModule,
     HttpClientModule,
     MatInputModule,
     ReactiveFormsModule,
     MatCardModule
    
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
