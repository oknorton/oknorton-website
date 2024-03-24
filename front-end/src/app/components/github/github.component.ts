import {Component, OnInit} from '@angular/core';
import {GitHubUser} from "../../Models/GitHubUser";
import {GithubService} from "../../Services/github-service.service";

@Component({
  selector: 'app-github',
  templateUrl: './github.component.html',
  styleUrls: ['./github.component.css']
})
export class GithubComponent implements OnInit {
  githubUser: GitHubUser | undefined;

  constructor(private githubService: GithubService) {
  }

  ngOnInit(): void {
    this.getUserData()
  }

  getUserData() {
    this.githubService.getUserData("oknorton").subscribe(
      (data: GitHubUser) => {
        this.githubUser = data;
      },
      (error: any) => {
        console.log('Error fetching GitHub data:', error);
      }
    );
  }
}


