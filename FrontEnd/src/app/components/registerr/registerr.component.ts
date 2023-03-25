import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-registerr',
  templateUrl: './registerr.component.html',
  styleUrls: ['./registerr.component.css']
})
export class RegisterrComponent implements OnInit{
  user:User
  constructor(private userService:UserService,private router:Router){
    this.user=new User()
  }
  ngOnInit(): void {
      // this.registerUser()
  }
  registerUser() {
    // this.user.name="abhinav";
    // this.user.name="abhinav";
    // this.user.location="bhopal";
    // this.user.email="abhinav@gmail.com";
    // this.user.role="user";
    // this.user.imagepath="abcdefg";

    this.userService.RegisterrUser(this.user).subscribe(res=>{
      if(res){
        console.log("Registration Success");
        Swal.fire(
          'User Registration',
          'Registered Successfully',
          'success'
        )
        this.router.navigate(['login'])
      }
    })
  }

}

