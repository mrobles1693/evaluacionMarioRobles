import { Injectable } from '@angular/core';
import { IPersonal } from './interfaces/personal';
import { FormGroup, FormControl, Validators} from "@angular/forms";
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonalService {

  _listPersonal : IPersonal[] = [];
  private obsPersonal$: Subject<IPersonal[]>;
  id: number = 1;

  constructor() {
    this.obsPersonal$ = new Subject();
  }

  listaPersonal$(){
    return this.obsPersonal$.asObservable();
  }

  addPersonal(personal){
    this._listPersonal.push({
      idPersonal: this.id,
      TipoDoc: personal.TipoDoc,
      NumeroDoc: personal.NumeroDoc,
      Nombre1: personal.Nombre1,
      ApPaterno: personal.ApPaterno,
      ApMaterno: personal.ApMaterno,
      NombreCompleto: personal.Nombre1 + ' ' + personal.ApPaterno + ' ' + personal.ApMaterno,
      FechaNac: personal.FechaNac,
      FechaIngreso: personal.FechaIngreso,
    });
    this.obsPersonal$.next(this._listPersonal);
    this.id++;
  }

  editPersonal(personalEditado){
    console.log('personal editado');
    console.log(personalEditado);
    this._listPersonal.forEach((personalBuscado,index)=>{
      console.log('Personal Buscado');
      console.log(personalBuscado);

      if(personalBuscado.idPersonal==personalEditado.idPersonal) {
        this._listPersonal[index] = {
          idPersonal: personalEditado.idPersonal,
          TipoDoc: personalEditado.TipoDoc,
          NumeroDoc: personalEditado.NumeroDoc,
          Nombre1: personalEditado.Nombre1,
          Nombre2: personalEditado.Nombre2,
          ApPaterno: personalEditado.ApPaterno,
          ApMaterno: personalEditado.ApMaterno,
          NombreCompleto: personalEditado.Nombre1 + ' ' + personalEditado.ApPaterno + ' ' + personalEditado.ApMaterno,
          FechaNac: personalEditado.FechaNac,
          FechaIngreso: personalEditado.FechaIngreso,
        };

        console.log('Lista Editada');
        console.log(this._listPersonal);
      }

    });
    this.obsPersonal$.next(this._listPersonal);
  }

  deletePersonal(idpersonal){
    this._listPersonal.forEach((personal,index)=>{
      if(personal.idPersonal==idpersonal) this._listPersonal.splice(index,1);
    });
    this.obsPersonal$.next(this._listPersonal);
  }

  formPersonal: FormGroup = new FormGroup({
    idPersonal: new FormControl(null),
    TipoDoc: new FormControl('', Validators.required),
    NumeroDoc: new FormControl('', Validators.required, Validators.minLength[8]),
    Nombre1: new FormControl('', Validators.required),
    Nombre2: new FormControl(''),
    ApPaterno: new FormControl('', Validators.required),
    ApMaterno: new FormControl('', Validators.required),
    FechaNac: new FormControl('', Validators.required),
    FechaIngreso: new FormControl('', Validators.required),
  });

  inicializarformPersonal(){
    this.formPersonal.setValue({
      idPersonal : null,
      TipoDoc:'', 
      NumeroDoc:'',
      Nombre1:'', 
      Nombre2:'', 
      ApPaterno:'', 
      ApMaterno:'', 
      FechaNac:'', 
      FechaIngreso:''
    });
  }

  llenarformPersonal(personal) {
    this.formPersonal.setValue({
      idPersonal: personal.idPersonal,
      TipoDoc: personal.TipoDoc,
      NumeroDoc:  personal.NumeroDoc,
      Nombre1:  personal.Nombre1,
      Nombre2: personal.Nombre2 ? personal.Nombre2 : '',
      ApPaterno:  personal.ApPaterno,
      ApMaterno:  personal.ApMaterno,
      FechaNac:  personal.FechaNac,
      FechaIngreso:  personal.FechaIngreso,
    });
  }

}
