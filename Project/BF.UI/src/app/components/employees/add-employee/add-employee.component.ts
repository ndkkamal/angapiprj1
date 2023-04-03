import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee-model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {





  addEmployeeRequest: Employee = {
    id: 1,
    name: '',
    email:'',
    phone:'',
    salary:0,
    department:''
  };


  constructor(private fb: FormBuilder, private employeeService: EmployeesService, private router: Router) { }

 addForm!: FormGroup;

  ngOnInit(): void {
    this.addForm = this.fb.group({
      name: [null, Validators.required],
      email: [null, Validators.required],
      phone: [null, Validators.required],
      salary: [0, Validators.required],
      department: [null, Validators.required]
    });     
    

  }

  addEmployee() {
    
    this.employeeService.addEmployee(this.addEmployeeRequest)
    .subscribe({
      next: (employee) => {
       // this.router.navigate(['employees']);    
        console.log(this.addEmployeeRequest); 
      },
      error: (response) => {
        console.log(response);
      }
    
    })

}
}
