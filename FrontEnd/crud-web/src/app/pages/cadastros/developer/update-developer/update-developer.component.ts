import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Developer } from '../developer.model';
import { DeveloperService } from '../developer.service';

@Component({
  selector: 'app-update-developer',
  templateUrl: './update-developer.component.html',
  styleUrls: ['./update-developer.component.css']
})
export class UpdateDeveloperComponent implements OnInit {

  developerForm!: FormGroup;
  entity: Developer = new Developer();

  constructor(
    private fb: FormBuilder,
    private developerService: DeveloperService,
    private route: ActivatedRoute
  ) {
    this.entity = this.route.snapshot.data.entity;
   }

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
      id: [this.entity.id, []],
      nome: [this.entity.nome, [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      sexo: [this.entity.sexo, [Validators.required,  Validators.maxLength(1)]],
      idade: [this.entity.idade, [Validators.required, Validators.maxLength(3)]],
      hobby: [this.entity.hobby, [Validators.required, Validators.minLength(5), Validators.maxLength(100) ]],
      dataNascimento: [this.entity.dataNascimento, [Validators.required ]]
    })
  }

  salvar(): void {
    this.developerService.updateDeveloper(this.entity.id, this.developerForm.value)
    .subscribe(() => this.voltar());
  }

  voltar(): void {
    history.go(-1);
  }

  atualizaIdade(date: Date): void {
    let idade = Developer.calcularIdade(date);
    this.developerForm.patchValue({ idade: idade});
  }

}
