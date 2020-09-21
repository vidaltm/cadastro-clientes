import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ClienteService } from '../cliente.service';  
import { Cliente } from '../cliente'; 
import { Cep } from '../cep';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  dataSaved = false;  
  clienteForm: any;  
  allClientes: Observable<Cliente[]>;  
  clienteIdUpdate = null;  
  message = null;

  constructor(private formBuilder: FormBuilder, private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.clienteForm = this.formBuilder.group({
      Nome: ['', [Validators.required]],  
      DataNascimento: ['', [Validators.required]],
      Sexo:['', [Validators.required]],
      Cep: [''],
      Endereco: [''],
      Numero: [''],
      Complemento: [''],
      Bairro: [''],
      Estado: [''],
      Cidade: [''],
    });
    this.loadAllClientes();
  }

  loadAllClientes() {  
    this.allClientes = this.clienteService.getAllCliente();  
  }

  onFormSubmit() {  
    this.dataSaved = false;  
    const cliente = this.clienteForm.value;  
    this.CreateCliente(cliente);  
    this.clienteForm.reset();  
  }
  
  CreateCliente(cliente: Cliente) {  
    if (this.clienteIdUpdate == null) {  
      this.clienteService.createCliente(cliente).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Registro salvo com sucesso';  
          this.loadAllClientes();  
          this.clienteIdUpdate = null;  
          this.clienteForm.reset();  
        }  
      );  
    } else {  
      cliente.id = this.clienteIdUpdate;  
      this.clienteService.updateCliente(this.clienteIdUpdate,cliente).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro atualizado com sucesso';  
        this.loadAllClientes();  
        this.clienteIdUpdate = null;  
        this.clienteForm.reset();  
      });  
    }  
  }

  loadClienteToEdit(id: string) {  
    this.clienteService.getClienteById(id).subscribe(cliente=> {  
      this.message = null;  
      this.dataSaved = false;  
      this.clienteIdUpdate = cliente.id;  
      this.clienteForm.controls['Nome'].setValue(cliente.nome);  
      this.clienteForm.controls['DataNascimento'].setValue(cliente.dataNascimento);
      this.clienteForm.controls['Sexo'].setValue(cliente.sexo);
      this.clienteForm.controls['Cep'].setValue(cliente.cep);
      this.clienteForm.controls['Endereco'].setValue(cliente.endereco);
      this.clienteForm.controls['Numero'].setValue(cliente.numero);
      this.clienteForm.controls['Complemento'].setValue(cliente.complemento);
      this.clienteForm.controls['Bairro'].setValue(cliente.bairro);
      this.clienteForm.controls['Cidade'].setValue(cliente.cidade);
      this.clienteForm.controls['Estado'].setValue(cliente.estado);
    });    
  }

  deleteCliente(id: string) {  
    if (confirm("Deseja realmente deletar este cliente ?")) {   
      this.clienteService.deleteCliente(id).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro deletado com sucesso';  
        this.loadAllClientes();  
        this.clienteIdUpdate = null;  
        this.clienteForm.reset();  
      });  
    }  
  }
  
  resetForm() {  
    this.clienteForm.reset();  
    this.message = null;  
    this.dataSaved = false;  
  }

  obterCep() {
    const cep = this.clienteForm.get("Cep").value;
    this.clienteService.obterCep(cep).subscribe(_cep => {          
          this.preencherEndereco(_cep);
        }        
      );
  }

  preencherEndereco(cep: Cep) {
    this.clienteForm.controls['Endereco'].setValue(cep.logradouro);
    this.clienteForm.controls['Numero'].setValue(cep.numero);
    this.clienteForm.controls['Complemento'].setValue(cep.complemento);
    this.clienteForm.controls['Bairro'].setValue(cep.bairro);
    this.clienteForm.controls['Cidade'].setValue(cep.localidade);
    this.clienteForm.controls['Estado'].setValue(cep.uf);    
  }

}
