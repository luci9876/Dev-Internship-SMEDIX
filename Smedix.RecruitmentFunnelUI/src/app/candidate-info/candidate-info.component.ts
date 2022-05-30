import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-candidate-info',
  templateUrl: './candidate-info.component.html',
  styleUrls: ['./candidate-info.component.scss']
})
export class CandidateInfoComponent implements OnInit {
  
  candidate!: any;

  constructor(private candidateService: CandidateService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getCandidate();
  }

  getCandidate(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.candidateService.getCandidate(id)
      .subscribe({
        next: candidate => { this.candidate = candidate },
        error: err => { console.log(err) }
      });
  }

}
