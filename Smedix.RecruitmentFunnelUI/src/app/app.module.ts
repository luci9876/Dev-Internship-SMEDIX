import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatSelectModule } from '@angular/material/select'
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CandidateCardComponent } from './candidate-card/candidate-card.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { CandidateInfoComponent } from './candidate-info/candidate-info.component';
import { HomeComponent } from './home/home.component';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { CandidateDetailsParentContainerComponent } from './candidate-details-parent-container/candidate-details-parent-container.component';
import { CandidateDetailsComponent } from './candidate-details-parent-container/candidate-details/candidate-details.component';
import { CandidateHistoryComponent } from './candidate-details-parent-container/candidate-history/candidate-history.component';
import { ContactInfoComponent } from './candidate-details-parent-container/candidate-details/contact-info/contact-info.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TechnicalInfoComponent } from './candidate-details-parent-container/candidate-details/technical-info/technical-info.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { PopupMessageComponent } from './utility/popup-message/popup-message.component';
import { NotesComponent } from './candidate-details-parent-container/candidate-details/notes/notes.component';
import { WorkflowCardComponent } from './candidate-details-parent-container/candidate-history/workflow-card/workflow-card.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    AppComponent,
    CandidateCardComponent,
    NavbarComponent,
    CandidateInfoComponent,
    HomeComponent,
    CandidateListComponent,
    CandidateDetailsParentContainerComponent,
    CandidateDetailsComponent,
    CandidateHistoryComponent,
    ContactInfoComponent,
    TechnicalInfoComponent,
    PopupMessageComponent,
    NotesComponent,
    WorkflowCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    AppRoutingModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    MatCardModule,
    MatPaginatorModule,
    MatCheckboxModule,
    ScrollingModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
