import {Injectable} from '@angular/core';
import {User, UserManager, UserManagerSettings} from "oidc-client";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private manager = new UserManager(this.clientSettings);
  private user: User | undefined;

  get clientSettings(): UserManagerSettings {
    const env = environment;
    return {
      authority: env.authority,
      client_id: env.client_id,
      redirect_uri: env.redirect_url,
      post_logout_redirect_uri: env.post_logout_redirect_uri,
      response_type: env.response_type,
      scope: env.scope,
      filterProtocolClaims: true,
      loadUserInfo: true,
    };
  }

  get hasToken(): boolean {
    return this.jwt != null;
  }

  get jwt(): string | null {
    return localStorage.getItem('jwt');
  }

  set jwt(jwt: string | null) {
    localStorage.setItem('jwt', jwt ?? 'unknown');
  }

  constructor() {
  }

  login(): void {
    this.manager.signinRedirect();
  }

  async completeAuthentication(): Promise<any> {
    this.user = await this.manager.signinRedirectCallback();
    this.jwt = this.user.access_token;
  }

  logout(): Promise<any> {
    localStorage.clear();
    return this.manager.signoutRedirect();
  }
}
