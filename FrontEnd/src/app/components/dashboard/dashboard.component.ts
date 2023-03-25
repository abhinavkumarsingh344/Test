import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  Courses?:Course[]
  displayName?:string|null
  constructor(private courseservice:CourseService,private router:Router){
  }
  collection:any=[];
ngOnInit(): void {
  this.courseservice.getAllCourses().subscribe(res=>{
    console.log(res);
    this.Courses=res
      
    })  
}
gotoUpdateComponent(id:any){
  this.router.navigate(['dashboard/editCourse',id])
}
gotoAddComponent(){
  this.router.navigate(['dashboard/AddCourse'])
}

gotoDeleteComponent(item:any){
console.warn(this.collection)
  this.collection.splice(item-1,1)

  this.courseservice.gotoDeleteComponent(item).subscribe((result)=>{
        console.warn(result)
        
  })
  
}

}