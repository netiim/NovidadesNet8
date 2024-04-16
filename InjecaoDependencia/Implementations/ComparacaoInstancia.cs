namespace InjecaoDependencia.Implementations
{
    public class ComparacaoInstancia
    {
        public string KeyInjecao { get; set; }
        public string InstanciaGeradaPeloConstrutor { get; set; }
        public string InstanciaGeradaParametro { get; set; }

        public override string ToString()
        {
            return $"{{KeyInjecao: {KeyInjecao} \n" +
                $"InstanciaGeradaPeloConstrutor: {InstanciaGeradaPeloConstrutor} \n" +
                $"InstanciaGeradaParametro: {InstanciaGeradaParametro} }} \n";
        }
    }
}
