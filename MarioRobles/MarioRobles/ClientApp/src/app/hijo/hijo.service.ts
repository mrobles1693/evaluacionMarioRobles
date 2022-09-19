import { Injectable, Inject } from '@angular/core';
import { IHijo } from './interfaces/hijo';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IResponse } from '../response';

@Injectable({
  providedIn: 'root'
})
export class HijoService {

    _listHijo: IHijo[] = [];
    private obsHijo$: Subject<IHijo[]>;
    http: HttpClient;
    baseUrl: string;
    idPersonal: number;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.obsHijo$ = new Subject();
    }

    listaHijo$() {
        this.http.get<IResponse>(this.baseUrl + 'Hijo/' + this.idPersonal).toPromise().then(result => {
            this._listHijo = result.data as IHijo[];
            this.obsHijo$.next(this._listHijo);
        }, error => console.error(error));
        return this.obsHijo$.asObservable();
    }

    getHijos() {
        this.http.get<IResponse>(this.baseUrl + 'Hijo/' + this.idPersonal).subscribe(result => {
            this.obsHijo$.next(result.data as IHijo[]);
        });
    }

    addHijo(hijoAdd) {

        const hijo: IHijo = {
            idHijo: 0,
            idPersonal: this.idPersonal,
            tipoDoc: hijoAdd.tipoDoc,
            numeroDoc: hijoAdd.numeroDoc,
            nombre1: hijoAdd.nombre1,
            nombre2: hijoAdd.nombre2,
            apPaterno: hijoAdd.apPaterno,
            apMaterno: hijoAdd.apMaterno,
            nombreCompleto: '',
            fechaNac: hijoAdd.fechaNac,
        }

        this.http.put<IResponse>(this.baseUrl + 'Hijo', hijo).subscribe(result => {
            this.getHijos();
        });

    }

    editHijo(hijoEdit) {
        const hijo: IHijo = {
            idHijo: hijoEdit.idHijo,
            idPersonal: hijoEdit.idPersonal,
            tipoDoc: hijoEdit.tipoDoc,
            numeroDoc: hijoEdit.numeroDoc,
            nombre1: hijoEdit.nombre1,
            nombre2: hijoEdit.nombre2,
            apPaterno: hijoEdit.apPaterno,
            apMaterno: hijoEdit.apMaterno,
            nombreCompleto: '',
            fechaNac: hijoEdit.fechaNac,
        }

        this.http.post<IResponse>(this.baseUrl + 'Hijo', hijo).subscribe(result => {
            this.getHijos();
        });

    }

    deleteHijo(idHijo) {
        console.log('Del');
        this.http.delete<IResponse>(this.baseUrl + 'Hijo/' + idHijo).subscribe(result => {
            console.log('Result del');
            console.log(result);
            this.getHijos();
        });
    }

    formHijo: FormGroup = new FormGroup({
        idHijo: new FormControl(null),
        idPersonal: new FormControl(null),
        tipoDoc: new FormControl('', Validators.required),
        numeroDoc: new FormControl('', Validators.required, Validators.minLength[8]),
        nombre1: new FormControl('', Validators.required),
        nombre2: new FormControl(''),
        apPaterno: new FormControl('', Validators.required),
        apMaterno: new FormControl('', Validators.required),
        fechaNac: new FormControl('', Validators.required),
    });

    inicializarformHijo() {
        this.formHijo.setValue({
            idHijo: null,
            idPersonal: '',
            tipoDoc: '',
            numeroDoc: '',
            nombre1: '',
            nombre2: '',
            apPaterno: '',
            apMaterno: '',
            fechaNac: ''
        });
    }

    llenarformPersonal(hijo) {
        this.formHijo.setValue({
            idHijo: hijo.idHijo,
            idPersonal: hijo.idPersonal,
            tipoDoc: hijo.tipoDoc,
            numeroDoc: hijo.numeroDoc,
            nombre1: hijo.nombre1,
            nombre2: hijo.nombre2 ? hijo.nombre2 : '',
            apPaterno: hijo.apPaterno,
            apMaterno: hijo.apMaterno,
            fechaNac: hijo.fechaNac,
        });
    }
}
