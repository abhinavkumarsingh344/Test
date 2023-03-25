import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course } from '../models/course';
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  getCourse(tid:any):Observable<Course> {
    return this.httpclient.get<Course>(  'https://localhost:7092/api/Course/GetAllCourses')
  }
  GetUserDetails(displayName: any):Observable<Course> {
    return this.httpclient.get<Course>('https://localhost:7197/api/User/GetUserById/')
   
  }
  AddCourse(course: Course):Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:7092/api/Course/AddCourse',course)
  }
  editCourse(course: Course): Observable<boolean> {
    return  this.httpclient.put<boolean>('https://localhost:7092/api/Course/EditCourse/'+course.id,course)
    
  }
  getCourseById(id: any): Observable<Course> {
    return this.httpclient.get<Course>('https://localhost:7092/api/User/GetCourseById/'+id)
    
  }
  constructor(private httpclient:HttpClient) { }


  getAllCourses():Observable<Course[]> {
   return this.httpclient.get<Course[]>(  'https://localhost:7092/api/Course/GetAllCourses')

  }
  gotoDeleteComponent(id:any){
    return this.httpclient.delete('${this.https://localhost:7092/api/Course/Delete}/${id}')
  }
}
