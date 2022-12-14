import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

import { IPersonal } from '../interfaces/personal';

import { PersonalService } from '../personal.service';
import { HijoService } from '../../hijo/hijo.service';

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
    private hijoService: HijoService,
    public dialogFormTrabajador: MatDialog,
    public dialogHijos: MatDialog,
    ) { }

  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<IPersonal>();
  
  ngOnInit() {
    this.displayedColumns = ['idPersonal', 'nombreCompleto', 'tipoDoc', 'numeroDoc','fechaNac','fechaIngreso','options'];
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

  onHijos(idPersonal) {
    this.hijoService.idPersonal = idPersonal;
    this.dialogHijos.open(PrincipalHijoComponent, { width: '50%' });
  }

    applyFilter(event: Event) {
        const filterValue = (event.target as HTMLInputElement).value;
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }
}
