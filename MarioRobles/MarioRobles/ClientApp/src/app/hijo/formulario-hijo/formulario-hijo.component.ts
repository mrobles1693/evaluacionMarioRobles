import { Component, OnInit } from '@angular/core';
import { MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-formulario-hijo',
  templateUrl: './formulario-hijo.component.html',
  styleUrls: ['./formulario-hijo.component.css']
})
export class FormularioHijoComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<FormularioHijoComponent>
  ) { }

  ngOnInit() {
  }

}
