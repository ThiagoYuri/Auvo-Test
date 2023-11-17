using CsvHelper.Configuration;
using System.Globalization;

namespace Auvo.RH.Models.Map
{

    public sealed class ColaboradorMapCsv : ClassMap<Colaborador>
    {
        public ColaboradorMapCsv()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Codigo).Name("Código");
            Map(m => m.Nome).Name("Nome");
        }
    }
}
