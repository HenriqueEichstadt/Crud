import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DeveloperService } from '../developer.service';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { Developer } from '../developer.model';

@Component({
  selector: 'app-insert-developer',
  templateUrl: './insert-developer.component.html',
  styleUrls: ['./insert-developer.component.css']
})
export class InsertDeveloperComponent implements OnInit {

  developerForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private developerService: DeveloperService
  ) { }

  ngOnInit(): void {
    this.buildForm();
  }

  submitForm(): void {
    for (const i in this.developerForm.controls) {
      if (this.developerForm.controls.hasOwnProperty(i)) {
        this.developerForm.controls[i].markAsDirty();
        this.developerForm.controls[i].updateValueAndValidity();
      }
    }
  }

  buildForm() {
    this.developerForm = this.fb.group({
      id: [0, []],
      nome: [null, [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
      sexo: [null, [Validators.required,  Validators.maxLength(1)]],
      idade: [null, [Validators.required, Validators.maxLength(3)]],
      hobby: [null, [Validators.required, Validators.minLength(5), Validators.maxLength(100) ]],
      dataNascimento: [null, [Validators.required ]]
    }, {
      updateOn: 'blur'
    });
  }

  salvar(): void {
    this.developerService.saveDeveloper(this.developerForm.value).subscribe(
      () => this.voltar(),
      (error) => console.log("Erro: " + error));
  }

  voltar(): void {
    history.go(-1);
  }

  atualizaIdade(date: Date): void {
    let idade = Developer.calcularIdade(date);
    this.developerForm.patchValue({ idade: idade});
  }
}
