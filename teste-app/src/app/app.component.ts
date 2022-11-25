import { Component, OnInit } from '@angular/core';
import { PersonService } from './services/person.service';
import { Person } from './models/person';
import { NgForm } from '@angular/forms';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';  
import { PersonAddress } from './models/person-address';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class AppComponent implements OnInit{
  title = 'teste-app';

  dataSource : Person[] = []; 
  displayedColumns = ['Id', 'Nome', 'Documento', 'Telefone', 'DataAniversario','Ações'];
  isListagem: boolean = true;
  isNovaPessoa: boolean = true;

  formPerson: any;  

  person = {} as Person;
  persons: Person[] = [];

  //displayedColumnss: string[] = ['name', 'occupation', 'age'];
  displayedColumnss: string[] = COLUMNS_SCHEMA.map((col) => col.key);
  dataSourceAddress: PersonAddress[] = [];
  columnsSchema: any = COLUMNS_SCHEMA;


  constructor(private personService: PersonService, private formbulider: FormBuilder) {}

  ngOnInit() {

    this.formPerson = this.formbulider.group({  
      Nome: ['', [Validators.required]],  
      Documento: ['', [Validators.required]],  
      Telefone: ['', [Validators.required]],  
      DataAniversario: ['', [Validators.required]],  
    });  

    this.getAllPersons();
  }

  async onFormSubmit() {  
    const person = this.formPerson.value; 

    let personTemp: Person = {
      id: 0,
      name: person.Nome,
      dateBirthday: person.DataAniversario,
      document: person.Documento,
      phone: person.Telefone,
      personAddresses:[]
    };

    if(this.isNovaPessoa){
      this.personService.addPerson(personTemp).subscribe((person: Person) => {
        console.log(person);
      });
    }else{
      personTemp.id = this.person.id;
      this.personService.updatePerson(personTemp).subscribe((person: Person) => {
        console.log(person);
      });
    }

    await this.carregarPessoas();
  } 

  resetForm() {  
    this.formPerson.reset();     
  } 

  public carregarPessoas():void{
    this.getAllPersons();
    this.isListagem = true;
  }

  public alterarIncluirPessoa(element: Person) : void{
    console.log(element);
    this.person = element;
    
    this.formPerson.controls['Nome'].setValue(element.name);  
    this.formPerson.controls['Documento'].setValue(element.document);  
    this.formPerson.controls['Telefone'].setValue(element.phone);  
    this.formPerson.controls['DataAniversario'].setValue(element.dateBirthday);  

    this.dataSourceAddress = element.personAddresses;
    this.isListagem = false;
    this.isNovaPessoa = false;
  }

  public incluirPessoa(): void{
    this.isListagem = false;
    this.isNovaPessoa = true;
  }

  public removerPessoa(element: Person) : void{
    console.log(element);
    this.personService.deletePerson(element.id).subscribe(() => {
      console.log("id "+ element.id + " removido");
    }); 
    this.getAllPersons();
  }

  getAllPersons() {
    this.personService.getAllPersons().subscribe((persons: Person[]) => {
      this.persons = persons;
      this.dataSource = persons;
    });
  }

  addRow() {
    let newRow: PersonAddress = { id: 0, personId: 0, city: "", country: "", neighborhood:"", postalCode: "", street:""}; //{"name": "", "occupation": "", "dateOfBirth": "", "age": 0, isEdit: true}
    this.dataSourceAddress = [...this.dataSourceAddress, newRow];
  }

  async removerEndereco(element: PersonAddress){
    if(element.id > 0){
      await this.personService.deletePersonAddress(element.id).subscribe(() => {
        console.log("id "+ element.id + " removido");
      });      
    }
    this.dataSourceAddress = this.dataSourceAddress.filter((u) => u.id !== element.id);
  }
  
  async salvarAlteracoesEndereco(element: PersonAddress){
    if(element.id > 0){
      await this.personService.updatePersonAddress(element).subscribe((personAddresses: PersonAddress) => {
        console.log(personAddresses);
      });      
    }else{
      element.personId = this.person.id;
      await this.personService.addPersonAddress(element).subscribe((personAddresses: PersonAddress) => {
        console.log(personAddresses);
      });
    }
  }

}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const COLUMNS_SCHEMA = [
  {
    key: "street",
    type: "text",
    label: "Endereço"
},
{
    key: "neighborhood",
    type: "text",
    label: "Bairro"
},
{
    key: "city",
    type: "text",
    label: "Cidade"
},
{
    key: "postalCode",
    type: "text",
    label: "CEP"
},
{
  key: "country",
  type: "text",
  label: "País"
},
{
  key: "isEdit",
  type: "isEdit",
  label: ""
}
]