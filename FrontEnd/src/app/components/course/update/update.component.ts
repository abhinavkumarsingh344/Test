import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  course:Course;
  id:any;
  constructor(private courseService:CourseService ,private activatedRoute:ActivatedRoute,private router:Router){
    this.course=new Course()
  }
 
  ngOnInit(): void {
    this.id= this.activatedRoute.snapshot.paramMap.get('id')
    this.getCourseById(this.id)
   }
     getCourseById(id: any) {
      this.courseService.getCourseById(id).subscribe(res=>{
       this.course=res
       console.log(res);
       
      })
     }
    
    editCourse(){
      this.courseService.editCourse(this.course).subscribe(res=>{
        if(res){
          console.log(res);
          Swal.fire(
            'User Update',
                    'Updated  Successfully',
                    'success'
          )
          this.router.navigate(['dashboard'])
        }
      })
    }
    }
