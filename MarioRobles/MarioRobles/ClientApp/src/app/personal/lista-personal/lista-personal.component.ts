import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

import { IPersonal } from '../interfaces/personal';
import { PersonalService } from '../personal.service';
import { FormularioPersonalComponent } from '../formulario-personal/formulario-personal.component';
import { PrincipalHijoComponent } from '../../hijo/principal-hijo/principal-hijo.component';

@Component({
  selector: 'app-lista-personal',
  templateUrl: './lista-personal.component.html',
  styleUrls: ['./lista-personal.component.css']
})
export class ListaPersonalComponent implements OnInit {

  constructor(
    private personalService: PersonalService,
    public dialogFormTrabajador: MatDialog,
    public dialogHijos: MatDialog,
    ) { }

  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<IPersonal>();
  
  ngOnInit() {
    this.displayedColumns = ['idPersonal', 'NombreCompleto', 'TipoDoc', 'NumeroDoc','FechaNac','FechaIngreso','options'];
    this.personalService.listaPersonal$().subscribe(
      personas => {
        this.dataSource.data = personas;
      }
    );
  }

  onEdit(personal: IPersonal){
    this.personalService.llenarformPersonal(personal);
    this.dialogFormTrabajador.open(FormularioPersonalComponent,{width:'400px'});
  }

  onDelete(idPersonal){
    this.personalService.deletePersonal(idPersonal);
  }

  onHijos(idPersonal){
    this.dialogHijos.open(PrincipalHijoComponent,{width:'70%'})
  }

}
