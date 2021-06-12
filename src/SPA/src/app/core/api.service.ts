import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {AuthService} from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient, private authService: AuthService) {
  }

  isUserAuthenticated(): Observable<boolean> {
    return this.httpClient.get<boolean>(environment.baseApi + '/test/auth', {headers: {'Authorization': 'Bearer ' + this.authService.jwt}});
  }
}
