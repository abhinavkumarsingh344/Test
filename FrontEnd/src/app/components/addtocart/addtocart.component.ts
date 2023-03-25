import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/models/cart';
import { Course } from 'src/app/models/course';
import { User } from 'src/app/models/user';
import { CartService } from 'src/app/services/cart.service';
import { CourseService } from 'src/app/services/course.service';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit{
  course:Course
  Carts: Cart
  users:User
  displayName: any;
  constructor(private courseService:CourseService,private router:Router,private userService:UserService,private cartService:CartService){
    this.course=new Course()
    this.Carts=new Cart()
    this.users=new User()
  }
  ngOnInit(): void {
   
  }
  AddToCart(){
    this.cartService.addToCart(this.Carts).subscribe(res=>{
      if(res){
        console.log("Cart Added Success");
        Swal.fire(
          'Cart Added',
          'CartAdded Successfully',
          'success'
        )
        this.router.navigate(['user-dashboard'])
      }
  })

    }
    GetUserDetail(){
      this.courseService.GetUserDetails(this.displayName).subscribe({
        next:(res)=>{
          this.users=res
          const userId=this.users.id?.toString();
          localStorage.setItem('id',userId!);
        }
      })
    }
    AddCart(){
      const idd=Number(localStorage.getItem('id'));
      const tid=localStorage.getItem('id')
       this.courseService.getCourse(tid!).subscribe({
        next: (Response: Course) =>{
          console.log(Response);
          this.course=Response;
          this.Carts.Id=this.course.id;
          this.Carts.Id=this.users.id;
          this.Carts.Quantity=1;
          this.Carts.CourseId=this.course.id;
          this.Carts.CourseId=this.users.id;
next:(res: any) =>{
  console.log(res);
  
}

        }
       })
    }
}