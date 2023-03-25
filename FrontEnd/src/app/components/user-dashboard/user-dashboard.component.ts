import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/models/cart';
import { Course } from 'src/app/models/course';
import { CartService } from 'src/app/services/cart.service';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {
  Carts?:Cart[]
 
CourseQuantity: any;

handlequantity(val: string) {
if(this.CourseQuantity<1 && val=='plus'){
  this.CourseQuantity+=1;
}else if(this.CourseQuantity>1 && val=='min'){
  this.CourseQuantity-=1;
}
}
  Courses?:Course[]
  displayName?:string|null
  constructor(private courseservice:CourseService,private router:Router,private cartService:CartService){
  }
  collection:any=[];
ngOnInit(): void {
  this.courseservice.getAllCourses().subscribe(res=>{
    console.log(res);
    this.Courses=res
      
    })  
}
gotoAddToCartComponent(){
  if(this.Carts){
    //this.Carts.Quantity=this.CourseQuantity;
    if(!localStorage.getItem('user')){
      // this.cartService.AddToCart(this.Carts)
      
    }
    

  }
  this.router.navigate(['dashboard'])
}
}
  
