import { HttpErrorResponse, HttpResponse } from "@angular/common/http";

export interface ResponseModel {
    isSuccessful: boolean;
    responseCode: number;
    message: string;
    responseDate: string;
}

export interface SingleResponseModel<T> extends ResponseModel {
    data: T
}

export interface ResponseCodes {
    code: string;
    short_description: string;
    description: string;
    severity: string;
}

export interface ResponseToastOptions<T> {
    http?: HttpResponse<T> | HttpErrorResponse
    show: boolean
    error: boolean
    errorCode?: string
    message?: string
    titleMessage?: string
}

export interface Auditoria {
    usuarioCreacion: string;
    fechaCreacion: string;
    usuarioModificacion: string;
    fechaModificacion: string;
}