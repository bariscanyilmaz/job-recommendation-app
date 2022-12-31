import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { from, tap } from 'rxjs';
import { Entry } from '../models/entry';
import { Job } from '../models/job';
import { Question } from '../models/question';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  realisticScore = 0;
  investigationScore = 0;
  artisticScore = 0
  socialScore = 0;
  enterprisingScore = 0;
  conventionalScore = 0;

  questions: Question[] = [];
  jobs: Job[] = [];
  jobColumns = ['name', 'score']

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  dataSource: Question[] = [];
  isSatisfied = false;
  showJobs: boolean = false;
  showPie: boolean = false;
  single: any[];
  view: [number, number] = [700, 400];

  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;
  legendPosition: string = 'below';

  colorScheme = [{
    name: 'Relistic', value: '#FFAE00'
  }, {
    name: 'Investigation', value: '#634A00'
  }, {
    name: 'Artistic', value: '#383416'
  }, {
    name: 'Social', value: '#0C7D74'
  }, {
    name: 'Enterprising', value: '#0F353D'
  }, {
    name: 'Conventional', value: '#B1C49D'
  }]

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private _formBuilder: FormBuilder) {

  }

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });

    this.getQuestions();
  }

  check(question: Question) {
    question.isAnswered = true;
    question.isChecked = true;
  }

  uncheck(question: Question) {
    question.isChecked = false;
    question.isAnswered = true;
  }

  onPageChange($event: { pageIndex: number; pageSize: number; }) {
    this.dataSource = this.questions.slice($event.pageIndex * $event.pageSize,
      $event.pageIndex * $event.pageSize + $event.pageSize);
  }

  getQuestions() {
    this.http.get<Question[]>(this.baseUrl + 'home/questions').subscribe(result => {
      this.questions = result
      this.dataSource = this.questions.slice(0, 10);
    });
  }

  checkState() {
    this.realisticScore = 0;
    this.investigationScore = 0;
    this.artisticScore = 0
    this.socialScore = 0;
    this.enterprisingScore = 0;
    this.conventionalScore = 0;
    from(this.questions).subscribe({
      next: (x) => {
        if (x.isChecked) {
          this.realisticScore += x.realistic;
          this.investigationScore += x.investigation;
          this.artisticScore += x.artistic
          this.socialScore += x.social;
          this.enterprisingScore += x.enterprising;
          this.conventionalScore += x.conventional;
        }
      },
      error: (e) => {

      },
      complete: () => {
        this.single = [{
          "name": "Relistic",
          "value": this.realisticScore
        },
        {
          "name": "Investigation",
          "value": this.investigationScore
        },
        {
          "name": "Artistic",
          "value": this.artisticScore
        },
        {
          "name": "Social",
          "value": this.socialScore
        },
        {
          "name": "Enterprising",
          "value": this.enterprisingScore
        },
        {
          "name": "Conventional",
          "value": this.conventionalScore
        }]
        this.showPie = true;

      }
    });
  }

  listJobs() {
    this.http.get<Job[]>(this.baseUrl + "home/jobs").subscribe({
      next: (x) => {
        this.jobs = x;
        this.jobs.forEach(j => {
          j.score = (j.artistic * this.artisticScore) + (j.conventional * this.conventionalScore) +
            (j.enterprising * this.enterprisingScore) + (j.investigation * this.investigationScore) + (j.realistic * this.realisticScore) + (j.social * this.socialScore)
        })
      },
      complete: () => {
        this.jobs = this.jobs.sort((a, b) => b.score - a.score).slice(0, 10);
        this.showJobs = true;
      }
    })
  }
  saveEntry() {
    let entry = {
      id:0,
      realistic: this.realisticScore,
      artistic: this.artisticScore,
      conventional: this.conventionalScore,
      enterprising: this.enterprisingScore,
      investigation: this.investigationScore,
      social: this.socialScore
    } as Entry;


    this.http.post(this.baseUrl + 'home/addentry', entry).subscribe(x=>{
      this.showPie=false;
    });

  }
}
