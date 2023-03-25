import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login:Login
 // loginForm:FormGroup
constructor(private userService:UserService,private formBuilder:FormBuilder,private router:Router ){
  this.login=new Login()
//   this.loginForm=formBuilder.group({
// name:["",Validators.compose([Validators.required,Validators.minLength(4)])]
// password:["",Validators.compose([Validators.required,Validators.pattern("^[A-Z]{1}[a-z]{6}[@]{1}[0-9]{3}$")])]
  //})
}
  ngOnInit(): void {
  //  this.loginUser();
  }
  loginUser(loginForm:any) {
    this.loginUser=loginForm.value
    // this.login.name="user1";
    // this.login.password="user1";
    this.userService.login(this.login).subscribe(res=>{
console.log(res);
let jsonObject=JSON.stringify(res)
let jsonToken=JSON.parse(jsonObject)
console.log('User Token Received::${jsonToken["Token"]}');
localStorage.setItem('userToken',jsonToken["Token"])
localStorage.setItem('userName',jsonToken["Name"])
Swal.fire(
  'User Login',
          'Logged  Successfully',
          'success'
)
const name =localStorage.getItem('userRole')
if(name=="user2"){
  this.router.navigate(['dashboard'])
}else{
  this.router.navigate(['user-dashboard'])
}

    })
   
  }
}
