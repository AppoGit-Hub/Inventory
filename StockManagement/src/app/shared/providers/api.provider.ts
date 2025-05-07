import { Provider } from '@angular/core';

import { ApiConfiguration } from '@api-proxy/api-configuration';
import { environment } from '@environments/environment';

export function provideApiConfiguration(): Provider {
  return {
    provide: ApiConfiguration,
    useValue: {
      rootUrl: environment.apiUrl,
    },
  };
}
