import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

import { HijoService } from '../hijo.service';

@Component({
  selector: 'app-formulario-hijo',
  templateUrl: './formulario-hijo.component.html',
  styleUrls: ['./formulario-hijo.component.css']
})
export class FormularioHijoComponent implements OnInit {

    constructor(
        private service: HijoService,
        public dialogRef: MatDialogRef<FormularioHijoComponent>
    ) { }

    ngOnInit() {
    }

    onClear() {
        this.service.formHijo.reset();
        this.service.inicializarformHijo();
    }

    onClose() {
        this.onClear();
        this.dialogRef.close();
    }

    onSubmit() {
        if (this.service.formHijo.valid) {
            if (!this.service.formHijo.get('idHijo').value) {
                this.service.addHijo(this.service.formHijo.value);
            }
            else {
                console.log('ACTUALIZANDO...');
                this.service.editHijo(this.service.formHijo.value);
            }
            this.onClear();
            this.onClose();
        }
    }

}
