import {Component, OnInit} from '@angular/core';
import {AuthService} from "../core/auth.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {

  error = false;

  constructor(private authService: AuthService, private route: ActivatedRoute, private router: Router) {
  }

  async ngOnInit(): Promise<any> {
    const hasError = (this.route.snapshot.fragment?.indexOf('error') ?? -1) > 0;
    if (hasError) {
      this.error = true;
      return;
    } else {
      await this.authService.completeAuthentication();
      await this.router.navigate(['/']);
    }
  }

}
