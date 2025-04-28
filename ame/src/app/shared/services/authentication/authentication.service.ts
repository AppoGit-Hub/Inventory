import { inject, Injectable, OnDestroy } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { BehaviorSubject, Subscription } from 'rxjs';

import {
  UserModel,
  UserPermissions,
} from '@services/authentication/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService implements OnDestroy {
  private userSubject = new BehaviorSubject<UserModel | undefined>(undefined);

  user$ = this.userSubject.asObservable();

  private auth = inject(AuthService);
  private userSubscription!: Subscription;

  constructor() {
    this.init();
  }

  init(): void {
    this.userSubscription = this.auth.user$.subscribe((user) => {
      if (!user) {
        this.userSubject.next(undefined);
        return;
      }

      this.auth.getAccessTokenSilently().subscribe((token) => {
        const parsedToken = JSON.parse(atob(token.split('.')[1])) as {
          permissions: UserPermissions[];
        };

        this.userSubject.next({
          ...user,
          permissions: parsedToken.permissions,
        });
      });
    });
  }

  ngOnDestroy(): void {
    this.userSubscription.unsubscribe();
  }
}
