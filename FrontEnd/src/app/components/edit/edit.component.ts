import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit{
  user:User;
  id:any;
  constructor(private userService:UserService ,private activatedRoute:ActivatedRoute,private router:Router){
    this.user=new User()
  }
ngOnInit(): void{
 this.id= this.activatedRoute.snapshot.paramMap.get('id')
 this.getUserById(this.id)
}
  getUserById(id: any) {
   this.userService.getUserById(id).subscribe(res=>{
    this.user=res
    console.log(res);
    
   })
  }
editUser(){
  this.userService.editUser(this.user).subscribe(res=>{
    if(res){
      console.log(res);
      Swal.fire(
        'User Update',
                'Updated  Successfully',
                'success'
      )
      this.router.navigate(['admindashboard'])
    }
  })
}
}
