import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { MatTableDataSource } from '@angular/material/table';

import { IHijo } from '../interfaces/hijo';

import { HijoService } from '../hijo.service';

import { FormularioHijoComponent } from '../formulario-hijo/formulario-hijo.component';

@Component({
  selector: 'app-lista-hijo',
  templateUrl: './lista-hijo.component.html',
  styleUrls: ['./lista-hijo.component.css']
})
export class ListaHijoComponent implements OnInit {

    constructor(
        private hijoService: HijoService,
        public dialogFormHijo: MatDialog
    ) { }

    displayedColumns: string[] = [];
    dataSource = new MatTableDataSource<IHijo>();

    ngOnInit() {
        this.displayedColumns = ['idHijo', 'nombreCompleto', 'fechaNac', 'options'];
        this.hijoService.listaHijo$().subscribe(
            hijos => {
                this.dataSource.data = hijos;
            }
        );
    }

    onEdit(hijo: IHijo) {
        this.hijoService.llenarformPersonal(hijo);
        this.dialogFormHijo.open(FormularioHijoComponent, { width: '400px' });
    }

    onDelete(idHijo) {
        this.hijoService.deleteHijo(idHijo);
    }

    applyFilter(event: Event) {
        const filterValue = (event.target as HTMLInputElement).value;
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }
}
