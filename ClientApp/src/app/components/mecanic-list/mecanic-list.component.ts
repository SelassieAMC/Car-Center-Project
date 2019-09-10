import { MecanicService } from './../../services/mecanic.service';
import { Component, OnInit } from '@angular/core';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-mecanic-list',
  templateUrl: './mecanic-list.component.html',
  styleUrls: ['./mecanic-list.component.css']
})
export class MecanicListComponent implements OnInit {
  mecanicos: any[] ;

  constructor(private mecanicService : MecanicService, private toastr : ToastrManager) { }

  ngOnInit() {
    //debugger;
    this.mecanicService.obtenerMecanicos()
      .subscribe(result =>{
        //debugger;
        this.mecanicos = result;
      },error=>{
        this.toastr.errorToastr(
          'Error cargando información de mecanicos',
          'Error',
          {
            toastTimeout:5000,
            animate: 'slideFromTop',
            showCloseButton: false
          });
      });
      console.log(this.mecanicos);
  }

}
