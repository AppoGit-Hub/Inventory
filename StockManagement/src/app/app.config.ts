import {
  ApplicationConfig,
  provideZoneChangeDetection,
  isDevMode,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { withInterceptors, provideHttpClient } from '@angular/common/http';
import { authHttpInterceptorFn, provideAuth0 } from '@auth0/auth0-angular';
import { errorInterceptor } from '@lib/error.interceptor';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { environment } from '@environments/environment';
import { provideApiConfiguration } from '@providers/api.provider';
import { TranslocoHttpLoader } from './transloco-loader';
import { provideTransloco } from '@jsverse/transloco';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideAnimationsAsync(),
    provideHttpClient(
      withInterceptors([authHttpInterceptorFn, errorInterceptor]),
    ),
    provideAuth0({
      domain: `${environment.auth.domain}`,
      clientId: `${environment.auth.clientId}`,
      authorizationParams: {
        redirect_uri: `${environment.auth.redirectUri}`,
        audience: `${environment.auth.audience}`,
        scope: `${environment.auth.scope}`,
      },
      httpInterceptor: {
        allowedList: [
          {
            uri: `${environment.apiUrl}/*`,
            tokenOptions: {
              authorizationParams: {
                audience: `${environment.auth.audience}`,
              },
            },
          },
        ],
      },
    }),
    provideApiConfiguration(),
    provideHttpClient(),
    provideTransloco({
      config: {
        availableLangs: ['en', 'fr', 'nl'],
        defaultLang: 'en',
        // Remove this option if your application doesn't support changing language in runtime.
        reRenderOnLangChange: true,
        prodMode: !isDevMode(),
      },
      loader: TranslocoHttpLoader,
    }),
  ],
};
