import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {GitHubUser} from "../Models/GitHubUser";
import {Project} from "../Models/project";

@Injectable({
  providedIn: 'root'
})
export class GithubService {
  private baseUrl = 'https://api.github.com/';
  private apiURL = 'https://localhost:7154/Github';

  constructor(private http: HttpClient) { }

  getUserData(username: string): Observable<GitHubUser> {
    return this.http.get<GitHubUser>(`${this.apiURL}/${username}`);
  }

}
