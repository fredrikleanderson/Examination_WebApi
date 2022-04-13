import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UpdateUser } from 'src/models/update-user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-modification',
  templateUrl: './user-modification.component.html',
  styleUrls: ['./user-modification.component.scss']
})
export class UserModificationComponent implements OnInit {

  user?: User
  model: UpdateUser

  constructor(private userService:UserService) {
    this.model = new UpdateUser();
   }

  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.user = this.userService.loggedInUser
      this.model.firstName = this.user?.firstName
      this.model.lastName = this.user?.lastName
      this.model.streetAddress = this.user?.streetAddress
      this.model.postalCode = this.user?.postalCode
      this.model.city = this.user?.city
    }
  }

  UpdateUser(): void{
    if(this.user?.id){
      this.userService.updateUser(this.user.id, this.model).subscribe(response =>{
        console.log(response)
      })
    }
  }

}
