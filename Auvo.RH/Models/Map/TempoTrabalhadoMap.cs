using CsvHelper.Configuration;
using System.Globalization;

namespace Auvo.RH.Models.Map
{

    public sealed class TempoTrabalhadoMap : ClassMap<TempoTrabalhado>
    {
        public TempoTrabalhadoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.ValorHora).Name("Valor hora");
            Map(m => m.Data).Name("Data");
            Map(m => m.Entrada).Name("Entrada");
            Map(m => m.Saida).Name("Saída");
            Map(m => m.AlmocoInic).Name("Almoço");
        }
    }
}
