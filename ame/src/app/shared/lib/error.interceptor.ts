import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { TranslocoService } from '@jsverse/transloco';

import { ToastService } from '@services/notification/toast.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const notificationService = inject(ToastService);
  const translationService = inject(TranslocoService);

  return next(req).pipe(
    catchError((err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (req.url.includes('/i18n/')) {
          return throwError(() => err);
        }

        translationService.load(translationService.getActiveLang()).subscribe({
          next: () => {
            notificationService.addErrorNotification(
              translationService.translate('error.http.message'),
            );
          },
          error: () => {
            notificationService.addErrorNotification(
              'UNTRANSLATED: An error occurred',
            );
          },
        });
      }

      return throwError(() => err);
    }),
  );
};
