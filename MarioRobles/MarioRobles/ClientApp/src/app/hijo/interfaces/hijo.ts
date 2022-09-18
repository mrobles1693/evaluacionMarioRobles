export interface IHijo {
    idHijo:number,
    idPersonal:number,
    TipoDoc:string,
    NumeroDoc:string,
    ApPaterno:string,
    ApMaterno:string,
    Nombre1:string,
    Nombre2?:string,
    NombreCompleto:string,
    FechaNac:Date,
}