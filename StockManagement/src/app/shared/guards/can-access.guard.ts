import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { map, Observable, take } from 'rxjs';

import { AuthenticationService } from '@services/authentication/authentication.service';
import { AccessType } from '@services/authentication/models/user.model';
import { ToastService } from '@services/notification/toast.service';

enum AuthStatus {
  Unauthenticated,
  Authenticated,
}

export const createAccessGuard = (
  entity: string,
  accessType: AccessType,
): CanActivateFn => {
  return (): Observable<boolean> => {
    const authService = inject(AuthenticationService);
    const notificationService = inject(ToastService);

    return authService.user$.pipe(
      take(1),
      map((user) => {
        const authStatus =
          user !== undefined
            ? AuthStatus.Authenticated
            : AuthStatus.Unauthenticated;

        if (authStatus === AuthStatus.Unauthenticated) {
          notificationService.addErrorNotification(
            'You are not authenticated. Please log in first.',
          );
          return false;
        }

        const canAccess = user!.permissions.includes(`${accessType}:${entity}`);

        if (!canAccess) {
          notificationService.addErrorNotification(
            'You do not have permission to access this page.',
          );
        }

        return canAccess;
      }),
    );
  };
};
