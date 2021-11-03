import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Developer } from './developer.model';

@Injectable({
  providedIn: 'root'
})
export class DeveloperService implements Resolve<Developer> {

  constructor(
    private http: HttpClient
  ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Developer> {
    return this.getDeveloperById(route.params.id);
  }

  private baseUrl(): string {
    return `${environment.API}/Developers`;
  }

  /**
     * Busca todos os Desenvolvedores cadastrados
     */
  public getDevelopers(): Observable<Developer[]> {
    return this.http.get<Developer[]>(this.baseUrl());
  }

  /**
   * Busca o desenvolvedor pelo id
   */
  public getDeveloperById(id: number): Observable<Developer> {
    return this.http.get<Developer>(this.baseUrl() + `/${id}`);
  }

  /**
   * Salvar um novo desenvolvedor
   */
  public saveDeveloper(form: any): Observable<Developer> {
    return this.http.post<Developer>(this.baseUrl(), form);
  }

  /**
   * Atualizar um desenvolvedor existente
   */
  public updateDeveloper(id: number, form: any): Observable<Developer> {
    return this.http.put<Developer>(this.baseUrl() + `/${id}`, form);
  }

  /**
   * Deletar um desenvolvedor pelo id
   */
  public deleteDeveloper(id: number): Observable<void> {
    return this.http.delete<void>(this.baseUrl() + `/${id}`);
  }
}
