import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Cliente } from './cliente';
import { Cep } from './cep';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url = 'https://localhost:44336/api';
  constructor(private http: HttpClient) { }

  getAllCliente(): Observable<Cliente[]>{
    const apiUrl = `${this.url}/cliente/`;
    return this.http.get<Cliente[]>(apiUrl);
  }

  createCliente(cliente: Cliente): Observable<Cliente>{   
    const apiUrl = `${this.url}/cliente/`;
    return this.http.post<Cliente>(apiUrl, cliente, httpOptions);
  }

  updateCliente(id: string, cliente: Cliente): Observable<Cliente>{
    const apiUrl = `${this.url}/cliente/${id}`;
    return this.http.put<Cliente>(apiUrl, cliente, httpOptions);
  }

  deleteCliente(id: string): Observable<number>{
    const apiUrl = `${this.url}/cliente/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }

  getClienteById(id: string): Observable<Cliente> {  
    const apiurl = `${this.url}/cliente/${id}`;
    return this.http.get<Cliente>(apiurl);  
  }
  
  obterCep(cep:string): Observable<Cep>{
    const url = `${this.url}/cep/${cep}`
    return this.http.get<Cep>(url);
  }
}
