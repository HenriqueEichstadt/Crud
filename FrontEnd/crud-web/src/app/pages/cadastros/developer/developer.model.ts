export class Developer {
  id!: number;
  nome!: string;
  sexo!: string;
  idade!: number;
  hobby!: number;
  dataNascimento!: Date;

  public static converterSexo(sexo: string | undefined): string{
    if(sexo === "M"){
      return "Masculino";
    }
    else if(sexo === "F"){
      return "Feminino";
    }
    else if(sexo === "Z"){
      return "Não Especificado";
    }
    else{
      return "Inválido";
    }
  }

  public static calcularIdade(date: Date): number {
    if (date) {
      var timeDiff = Math.abs(Date.now() - new Date(date).getTime());
      return Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
    } else {
      return 0;
    }
  }
}
