import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormularioPersonalComponent } from '../formulario-personal/formulario-personal.component';
import { IPersonal } from '../interfaces/personal';
import { PersonalService } from '../personal.service';

@Component({
  selector: 'app-principal-personal',
  templateUrl: './principal-personal.component.html',
  styleUrls: ['./principal-personal.component.css']
})
export class PrincipalPersonalComponent {

  constructor(
    public dialogFormTrabajador: MatDialog, 
  ) { }

  nuevoPersonal: IPersonal = {
    idPersonal: 0,
    tipoDoc: '',
    numeroDoc: '',
    nombre1: '',
    nombre2: '',
    apPaterno: '',
    apMaterno: '',
    nombreCompleto: '',
    fechaNac: null,
    fechaIngreso: null,
  };

  abrirFormularioUsuario(): void {
    this.dialogFormTrabajador.open(
      FormularioPersonalComponent,{width:'400px'}
    );
  }

}
