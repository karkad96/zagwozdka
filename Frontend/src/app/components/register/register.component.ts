import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../../shared/register.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(public registerService: RegisterService, private toastrService: ToastrService) { }

  ngOnInit(): void {
	  this.registerService.formModel.reset();
  }

  onSubmit() {
	  this.registerService.register().subscribe(
		  (res: any) => {
			  if (res.succeeded) {
				  this.registerService.formModel.reset();
				  this.toastrService.success('Utworzono nowego użytkownika!', 'Rejestracja pomyślna.');
			  } else {
				  res.errors.forEach((element: any) => {
					  switch (element.code) {
						  case 'DuplicateUserName':
							  this.toastrService.error('Nazwa użytkownika jest już zajęta','Rejestracja niepomyślna.');
							  break;

						  default:
							  this.toastrService.error(element.description,'Registration failed.');
							  break;
					  }
				  });
			  }
		  }
	  );
  }

}
