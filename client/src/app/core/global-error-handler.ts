import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { NGXLogger } from "ngx-logger";
import { ErrorService } from "../shared/services/error.service";
import { NotificationService } from "../shared/services/notification.service";

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private injector: Injector) {}

  handleError(error: Error | HttpErrorResponse) {
    const errorService = this.injector.get(ErrorService);
    const logger = this.injector.get(NGXLogger);
    const notifier = this.injector.get(NotificationService);

    let message;
    if (error instanceof HttpErrorResponse) {
      // server-error
      message = errorService.getServerErrorMessage(error);
      notifier.showError(message);
    } else {
      // client-error
      message = errorService.getClientErrorMessage(error);
      notifier.showError(message);
    }
    // logging errors
    logger.error(message);
  }
}
