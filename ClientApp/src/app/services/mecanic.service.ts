import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MecanicService {
  protected endpoint = "/api/mecanicos";
  constructor(private http: Http) { }

  guardarMecanico(mecanico){
    return this.http.post(this.endpoint,mecanico)
    .pipe(map(res=>res.json()));
  }

  obtenerMecanicoByDocTipoDoc(doc,tipoDoc){
    return this.http.get(this.endpoint+'/getmecanico/'+doc+'/'+tipoDoc)
    .pipe(map(res=>res.json()));
  }

  eliminarMecanico(doc,tipoDoc){
    return this.http.delete(this.endpoint+'/'+doc+'/'+tipoDoc);
  }

  obtenerMecanicos(){
    return this.http.get(this.endpoint)
    .pipe(map(res => res.json()));
  }
}
