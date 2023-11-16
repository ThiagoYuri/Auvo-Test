using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace Auvo.RH.Models.Map
{

    public sealed class ColaboradorMap : ClassMap<Colaborador>
    {
        public ColaboradorMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Codigo).Name("Código");
            Map(m => m.Nome).Name("Nome");
        }
    }
}
