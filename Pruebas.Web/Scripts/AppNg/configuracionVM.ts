export class ConfiguracionVM {
  ConfiguracionId: number;
  Descripcion: string;
  Valor: string;

  constructor(configuracionId: number, descripcion: string, valor: string) {
      this.ConfiguracionId = configuracionId;
      this.Descripcion = descripcion;
      this.Valor = valor;
  }
}