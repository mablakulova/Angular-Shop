import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
})
export class FileUploaderComponent {
  @Output() imageUploaded = new EventEmitter();
  imageChangedEvent: any;

  processFile(event: any) {
    let file;

    if (
      (file = event.target.files[0]) &&
      (file.type === 'image/png' || file.type === 'image/jpeg')
    ) {
      this.readFileAsDataURL(file).then((dataUrl) => {
        this.imageUploaded.emit(dataUrl);
      });
    } else {
      throw Error('Unsupported File Type. Only jpeg and png is allowed!');
    }
  }

  private readFileAsDataURL = (file:File) => {
    return new Promise((resolve) => {
      const fileReader = new FileReader();
      fileReader.onload = () => resolve(fileReader.result);
      fileReader.readAsDataURL(file as File);
    });
  };
}
