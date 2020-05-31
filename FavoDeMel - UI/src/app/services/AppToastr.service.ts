import { Injectable } from '@angular/core';
import { ToastrService, GlobalConfig } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AppToastrService {
  options: GlobalConfig;

  constructor(private toastrService: ToastrService) {
    this.options = this.toastrService.toastrConfig;
    this.options.positionClass = 'toast-top-right';
    this.options.newestOnTop = true;
    this.options.countDuplicates = true;
    this.options.preventDuplicates = true;   
    this.options.enableHtml = true;
    this.options.closeButton = true;  
    this.options.progressBar = true;
  }

  showSuccessMessage(title, message) {
    this.toastrService.success(message, title, this.options);
  }

  showWarningMessage(title, message) {
    this.toastrService.warning(message, title, this.options);
  }

  showInfoMessage(title, message) {
    this.toastrService.info(message, title, this.options);
  }

  showErrorMessage(title, message) {
    this.toastrService.error(message, title, this.options);
  }
}
