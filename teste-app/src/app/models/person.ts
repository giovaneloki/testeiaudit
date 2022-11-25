import { PersonAddress } from "./person-address";

export class Person {
    id: number = 0;
    name: string = "";
    document: string = "";
    phone: string = "";
    dateBirthday: Date = new Date();
    personAddresses: PersonAddress[] = []
}
