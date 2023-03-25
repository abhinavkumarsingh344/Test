import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit{
  course:Course
  constructor(private courseService:CourseService,private router:Router){
    this.course=new Course()
  }
  ngOnInit(): void {
} AddCourse() {

this.courseService.AddCourse(this.course).subscribe(res=>{
  if(res){
    console.log("Registration Success");
    Swal.fire(
      'Course Addition',
      'Course Added  Successfully',
      'success'
    )
    this.router.navigate(['dashboard'])
  }
})
}
}