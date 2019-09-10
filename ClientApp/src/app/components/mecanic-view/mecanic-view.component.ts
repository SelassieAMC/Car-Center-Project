import { MecanicService } from './../../services/mecanic.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-mecanic-view',
  templateUrl: './mecanic-view.component.html',
  styleUrls: ['./mecanic-view.component.css']
})
export class MecanicViewComponent implements OnInit {
  mecanico : any = {};
  columnsToDisplay = ['Nombre','Apellido', 'Celular'];
  tipos: any[] = [
    {value: 'CC'},
    {value: 'CE'},
    {value: 'PP'}
  ];
  constructor(
    private route: ActivatedRoute,
    private mecanicService: MecanicService, 
    private router : Router,
    private toastr : ToastrManager) { 
      route.params.subscribe(r => {
        debugger;
        this.mecanico.documento = r['doc'];
        this.mecanico.tipoDocumento = r['tipoDoc'];
      });
    }

  ngOnInit() {
    if(this.mecanico.documento && this.mecanico.tipoDocumento){
      //console.log(this.mecanico);
      this.mecanicService.obtenerMecanicoByDocTipoDoc(this.mecanico.documento, this.mecanico.tipoDocumento)
      .subscribe(result => {
        this.mecanico = result;
      })
    }
  }

  submit(){
    //console.log(this.mecanico);
    this.mecanicService.guardarMecanico(this.mecanico)
      .subscribe( result => {
        this.mecanico = result;
        this.toastr.successToastr(
          'Informacion guardada con exito',
          'Success',
          {
            toastTimeout:5000,
            animate: 'slideFromTop',
            showCloseButton: false
          });
      },error =>{
        this.toastr.errorToastr(
          'Error en la creacion',
          'Error',
          {
            toastTimeout:5000,
            animate: 'slideFromTop',
            showCloseButton: false
          });
      });
  }

  eliminarMecanico(){
    if(this.mecanico.documento && this.mecanico.tipoDocumento){
      this.mecanicService.eliminarMecanico(this.mecanico.documento, this.mecanico.tipoDocumento)
        .subscribe(result => {
          this.toastr.successToastr(
            'Mecanico eliminado',
            'Success',
            {
              toastTimeout:5000,
              animate: 'slideFromTop',
              showCloseButton: false
            });
          this.router.navigate(['']);
        },error =>{
          this.toastr.errorToastr(
            'Ha ocurrido un error',
            'Error',
            {
              toastTimeout:5000,
              animate: 'slideFromTop',
              showCloseButton: false
            });
        });
    }
  }
}
