import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StarComponent } from './components/star/star.component';
import { FileUploaderComponent } from './components/file-uploader/file-uploader.component';
import { MaterialModule } from './material.module';
import { HighlightDirective } from './directives/highlight.directive';
import { ConvertToSpacesPipe } from './pipes/convert-to-spaces.pipe';
import { TranslocoRootModule } from './transloco-root.module'

@NgModule({
  declarations: [StarComponent, FileUploaderComponent, HighlightDirective, ConvertToSpacesPipe],
  imports: [CommonModule, MaterialModule, TranslocoRootModule],
  exports: [
    StarComponent, 
    FileUploaderComponent,
    MaterialModule,
    HighlightDirective,
    ConvertToSpacesPipe,
    TranslocoRootModule
  ],
  providers: []
})
export class SharedModule {}
