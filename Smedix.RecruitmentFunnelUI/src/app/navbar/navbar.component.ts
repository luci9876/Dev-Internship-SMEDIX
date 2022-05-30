import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})



export class NavbarComponent implements OnInit {
  title: String = "HR Recruitment Funnel";
  constructor(private router: Router) { }

  private log(message: String){
    console.log("NavbarComponent: " + message);
  }

  ngOnInit(): void {

  }

  public setTitle(newTitle: String): void{
    if(newTitle.length == 0){
      this.log("new title is an empty string")
    }

    this.title = newTitle;
  }

  public homeClicked(){
    this.router.navigateByUrl('')
  }

  public userProfileClicked(){
    this.log("user profile button pressed")
  }

  public notificationsClicked(){
    this.log("notifications button pressed")
  }

  public titleClicked(){
    this.router.navigateByUrl('')
  }

}
