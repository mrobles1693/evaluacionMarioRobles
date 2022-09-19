import { Component, OnInit } from '@angular/core';
import { MatDialogRef} from '@angular/material/dialog';

import { PersonalService } from '../personal.service';

@Component({
  selector: 'app-formulario-personal',
  templateUrl: './formulario-personal.component.html',
  styleUrls: ['./formulario-personal.component.css']
})
export class FormularioPersonalComponent implements OnInit {

  constructor(
    private service: PersonalService,
    public dialogRef: MatDialogRef<FormularioPersonalComponent>) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
  }

  onClear() {
    this.service.formPersonal.reset();
    this.service.inicializarformPersonal();
  }

  onClose() {
    this.onClear();
    this.dialogRef.close();
  }

  onSubmit() {
    if (this.service.formPersonal.valid) {
      if (!this.service.formPersonal.get('idPersonal').value){
        this.service.addPersonal(this.service.formPersonal.value);
      }
      else{
        console.log('ACTUALIZANDO...');
        this.service.editPersonal(this.service.formPersonal.value);
      }
      this.onClear();
      this.onClose();
    }
  }

}
