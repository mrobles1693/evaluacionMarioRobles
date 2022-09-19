import { Injectable, Inject } from '@angular/core';
import { IPersonal } from './interfaces/personal';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IResponse } from '../response';

@Injectable({
    providedIn: 'root'
})
export class PersonalService {

    _listPersonal: IPersonal[] = [];
    private obsPersonal$: Subject<IPersonal[]>;
    http: HttpClient;
    baseUrl: string;
    fechaActual: Date = new Date();
    fechaMax: Date = new Date();

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.obsPersonal$ = new Subject();
        this.fechaMax.setFullYear(this.fechaActual.getFullYear() - 18);
        this.fechaActual.setDate(this.fechaActual.getDate() + 1);
    }

    listaPersonal$() {
        this.http.get<IResponse>(this.baseUrl + 'Personal').subscribe(result => {
            this._listPersonal = result.data as IPersonal[];
            this.obsPersonal$.next(this._listPersonal);
        });
        return this.obsPersonal$.asObservable();
    }

    getListaPersonal() {
        this.http.get<IResponse>(this.baseUrl + 'Personal').subscribe(result => {
            this.obsPersonal$.next(result.data as IPersonal[]);
        });
    }

    addPersonal(personal) {
        const pers: IPersonal = {
            idPersonal: 0,
            tipoDoc: personal.tipoDoc,
            numeroDoc: personal.numeroDoc,
            nombre1: personal.nombre1,
            nombre2: personal.nombre2,
            apPaterno: personal.apPaterno,
            apMaterno: personal.apMaterno,
            nombreCompleto: personal.nombre1 + ' ' + personal.apPaterno + ' ' + personal.apMaterno,
            fechaNac: personal.fechaNac,
            fechaIngreso: personal.fechaIngreso,
        }

        this.http.put<IResponse>(this.baseUrl + 'Personal', pers).subscribe(result => {
            this.getListaPersonal();
        });
    }

    editPersonal(personalEditado) {
        const pers: IPersonal = {
            idPersonal: personalEditado.idPersonal,
            tipoDoc: personalEditado.tipoDoc,
            numeroDoc: personalEditado.numeroDoc,
            nombre1: personalEditado.nombre1,
            nombre2: personalEditado.nombre2,
            apPaterno: personalEditado.apPaterno,
            apMaterno: personalEditado.apMaterno,
            nombreCompleto: personalEditado.nombre1 + ' ' + personalEditado.apPaterno + ' ' + personalEditado.apMaterno,
            fechaNac: personalEditado.fechaNac,
            fechaIngreso: personalEditado.fechaIngreso,
        };

        this.http.post<IResponse>(this.baseUrl + 'Personal', pers).subscribe(result => {
            this.getListaPersonal();
        });

    }

    deletePersonal(idpersonal) {
        console.log('Del');
        this.http.delete<IResponse>(this.baseUrl + 'Personal/' + idpersonal).subscribe(result => {
            console.log('Result del');
            console.log(result);
            this.getListaPersonal();
        });
    }

    formPersonal: FormGroup = new FormGroup({
        idPersonal: new FormControl(null),
        tipoDoc: new FormControl('', Validators.required),
        numeroDoc: new FormControl('', Validators.required, Validators.minLength[8]),
        nombre1: new FormControl('', Validators.required),
        nombre2: new FormControl(''),
        apPaterno: new FormControl('', Validators.required),
        apMaterno: new FormControl('', Validators.required),
        fechaNac: new FormControl('', Validators.required),
        fechaIngreso: new FormControl('', Validators.required),
    });

    inicializarformPersonal() {
        this.formPersonal.setValue({
            idPersonal: null,
            tipoDoc: '',
            numeroDoc: '',
            nombre1: '',
            nombre2: '',
            apPaterno: '',
            apMaterno: '',
            fechaNac: '',
            fechaIngreso: ''
        });
    }

    llenarformPersonal(personal) {
        this.formPersonal.setValue({
            idPersonal: personal.idPersonal,
            tipoDoc: personal.tipoDoc,
            numeroDoc: personal.numeroDoc,
            nombre1: personal.nombre1,
            nombre2: personal.nombre2 ? personal.nombre2 : '',
            apPaterno: personal.apPaterno,
            apMaterno: personal.apMaterno,
            fechaNac: personal.fechaNac,
            fechaIngreso: personal.fechaIngreso,
        });
    }

}
