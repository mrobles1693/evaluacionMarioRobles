import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormularioHijoComponent } from './formulario-hijo/formulario-hijo.component';
import { ListaHijoComponent } from './lista-hijo/lista-hijo.component';
import { PrincipalHijoComponent } from './principal-hijo/principal-hijo.component';

@NgModule({
  declarations: [
    FormularioHijoComponent,
    ListaHijoComponent,
    PrincipalHijoComponent
  ],
  entryComponents:[
    PrincipalHijoComponent,
    FormularioHijoComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports:[
    PrincipalHijoComponent
  ]
})
export class HijoModule { }
