import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admindashboard',
  templateUrl: './admindashboard.component.html',
  styleUrls: ['./admindashboard.component.css']
})
export class AdmindashboardComponent implements OnInit{
  users?:User[]
constructor(private userService:UserService,private router:Router){  
}
collection:any=[];
  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(res=>{
      console.log(res);
      this.users=res
    })
  }
  gotoUpdateeComponent(id:any){
  this.router.navigate(['admindashboard/editUser',id])
}
gotoDeleteComponent(id:any){
 this.userService.gotoDeleteComponent(id).subscribe({
  next:(res) =>{
    alert('Employee deleted');
    this.router.navigate(['admindashboard'])
  },
  error:console.log,
  
  
 });
          
    
}
}

