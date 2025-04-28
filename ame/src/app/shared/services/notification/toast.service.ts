import { inject, Injectable } from '@angular/core';
import {
  NotificationService,
  type NotificationSettings,
  type Position as ToastPosition,
  type Type as NotificationType,
} from '@progress/kendo-angular-notification';

type ToastSeverity = NotificationType['style'];
type ToastMessage = NotificationSettings['content'];

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  private readonly NOTIFICATION_DURATION = 500;
  private readonly NOTIFICATION_TYPE = 'slide';

  private readonly NOTIFICATION_HORIZONTAL_POSITION: ToastPosition['horizontal'] =
    'center';
  private readonly NOTIFICATION_VERTICAL_POSITION: ToastPosition['vertical'] =
    'bottom';

  private _notificationService = inject(NotificationService);

  addSuccessNotification(message: ToastMessage) {
    this.addNotification(message, 'success');
  }

  addErrorNotification(message: ToastMessage) {
    this.addNotification(message, 'error');
  }

  addInfoNotification(message: ToastMessage) {
    this.addNotification(message, 'info');
  }

  addWarningNotification(message: ToastMessage) {
    this.addNotification(message, 'warning');
  }

  addNotification(message: ToastMessage, severity: ToastSeverity = 'none') {
    this._notificationService.show({
      content: message,
      animation: {
        type: this.NOTIFICATION_TYPE,
        duration: this.NOTIFICATION_DURATION,
      },
      cssClass: 'toast',
      type: {
        style: severity,
      },
      position: {
        horizontal: this.NOTIFICATION_HORIZONTAL_POSITION,
        vertical: this.NOTIFICATION_VERTICAL_POSITION,
      },
    });
  }
}
