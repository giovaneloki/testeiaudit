import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Person } from '../models/person';
import { PersonAddress } from '../models/person-address';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  url = 'https://localhost:7188/Person/'; // api rest fake

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  }

  getAllPersons(): Observable<Person[]> {
    return this.httpClient.get<Person[]>(this.url+"GetAll")
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  addPerson(entity: Person): Observable<Person> {
    return this.httpClient.post<Person>(this.url+"AddPerson", entity, this.httpOptions)
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  updatePerson(entity: Person): Observable<Person> {
    return this.httpClient.put<Person>(this.url+"UpdatePerson", entity, this.httpOptions)
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  deletePerson(id: number): Observable<void> {
    return this.httpClient.delete<void>(this.url+"DeletePerson/"+id, this.httpOptions)
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  addPersonAddress(entity: PersonAddress): Observable<PersonAddress> {
    return this.httpClient.post<PersonAddress>(this.url+"AddPersonAddress", entity, this.httpOptions)
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  updatePersonAddress(entity: PersonAddress): Observable<PersonAddress> {
    return this.httpClient.put<PersonAddress>(this.url+"UpdatePersonAddress", entity, this.httpOptions)
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  deletePersonAddress(id: number): Observable<void> {
    return this.httpClient.delete<void>(this.url+"DeletePersonAddress/"+id, this.httpOptions)
      .pipe(
       retry(2),
       catchError(this.handleError))
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}
