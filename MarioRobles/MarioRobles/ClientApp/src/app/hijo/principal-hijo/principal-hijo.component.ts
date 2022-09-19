import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogRef} from '@angular/material/dialog';

import { FormularioHijoComponent } from '../formulario-hijo/formulario-hijo.component';

@Component({
  selector: 'app-principal-hijo',
  templateUrl: './principal-hijo.component.html',
  styleUrls: ['./principal-hijo.component.css']
})
export class PrincipalHijoComponent implements OnInit {

    idPersonal: number = 0;

  constructor(
    public dialogRef: MatDialogRef<PrincipalHijoComponent>,
    public dialogFormHijos: MatDialog,
  ) { }

  ngOnInit() {
  }

  abrirFormularioHijo(idPersonal){
    this.dialogFormHijos.open(FormularioHijoComponent,{width:'400px'});
  }

  cerrarFormulario(){
    this.dialogRef.close();
  }
}
