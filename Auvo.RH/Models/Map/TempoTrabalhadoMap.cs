﻿using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Auvo.RH.Models.Map
{

    public sealed class TempoTrabalhadoMap : ClassMap<TempoTrabalhado>
    {
        public TempoTrabalhadoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Colaborador.Codigo).Name("Código");
            Map(m => m.ValorHora).Name("Valor hora");
            Map(m => m.Data).Name("Data").TypeConverter<DataConvert>();
            Map(m => m.Entrada).Name("Entrada");
            Map(m => m.Saida).Name("Saída");
            Map(m => m.Almoco).Name("Almoço");

        }
    }

    public class DataConvert : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string pattern = @"^\d{2}-\d{2}$";
            if(!Regex.IsMatch(text, pattern))
            {
                throw new Exception("Data no csv Incorreta");
            }

            DateTime dataConvertida = DateTime.ParseExact(text, "dd-MM", null);

            return dataConvertida;
        }
    }


}
