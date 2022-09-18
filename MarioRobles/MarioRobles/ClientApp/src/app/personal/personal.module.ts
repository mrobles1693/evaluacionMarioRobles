import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrincipalPersonalComponent } from './principal-personal/principal-personal.component';
import { ListaPersonalComponent } from './lista-personal/lista-personal.component';
import { FormularioPersonalComponent } from './formulario-personal/formulario-personal.component';
import { MaterialModule } from '../material/material.module';
import { PrincipalHijoComponent } from '../hijo/principal-hijo/principal-hijo.component';
import { HijoModule } from '../hijo/hijo.module';
import { FormularioHijoComponent } from '../hijo/formulario-hijo/formulario-hijo.component';

@NgModule({
  declarations: [
    PrincipalPersonalComponent, 
    ListaPersonalComponent, 
    FormularioPersonalComponent,
  ],
  entryComponents:[
    FormularioPersonalComponent,
    PrincipalHijoComponent,
    FormularioHijoComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HijoModule
  ],
  exports:[
    PrincipalPersonalComponent,
  ]
})
export class PersonalModule { }
