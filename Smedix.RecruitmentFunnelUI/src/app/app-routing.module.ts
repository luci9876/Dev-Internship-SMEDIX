import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateDetailsParentContainerComponent } from './candidate-details-parent-container/candidate-details-parent-container.component';
import { CandidateDetailsComponent } from './candidate-details-parent-container/candidate-details/candidate-details.component';
import { CandidateHistoryComponent } from './candidate-details-parent-container/candidate-history/candidate-history.component';
import { CandidateListComponent } from './candidate-list/candidate-list.component';

const routes: Routes = [
  { path: "candidate-details/:id",
    children: [
      {path: "candidate-details", component: CandidateDetailsComponent},
      {path: "history/:id", component: CandidateHistoryComponent},
    ], component: CandidateDetailsParentContainerComponent
  },
  {path: '', component: CandidateListComponent},
  {path: '**', component: CandidateListComponent, pathMatch: 'full'},
  {path: 'candidate-info/:id', component: CandidateDetailsParentContainerComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
