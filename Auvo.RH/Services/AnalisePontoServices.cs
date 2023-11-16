using Auvo.RH.DAL;
using Auvo.RH.DAL.Models;
using Auvo.RH.Models;
using Auvo.RH.Models.Map;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

namespace Auvo.RH.Services
{
    public class AnalisePontoServices
    {
        private ContextDb _context;

        public AnalisePontoServices(ContextDb context)
        {
            _context = context;
        }

        public async void UpdateData(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);

                #region Validação
                if (string.Equals(fileName, ".csv", StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Erro: Arquivos que não são .csv forám encontrados");
                #endregion

                string nomeDepartamento = fileName.Split('-')[0];
                //Criar Departamento
                if (!(_context.Departamento.Any(dep => dep.Nome == nomeDepartamento)))
                {
                    _context.Departamento.Add(new Departamento() { Nome = nomeDepartamento });
                    _context.SaveChanges();
                }
                var departamento = _context.Departamento.First(dep => dep.Nome == nomeDepartamento);



                //Criar Colaborador e TempoTrabalhado
                if (file != null && file.Length > 0)
                {
                    CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";",
                        TrimOptions = TrimOptions.Trim,
                        MissingFieldFound = null,
                        HeaderValidated = null,
                        Encoding = Encoding.UTF8,
                    };
                    #region  Salvar colaborador
                    using (Stream stream = file.OpenReadStream())
                    using (var csv = new CsvReader(new StreamReader(stream), configuration))
                    {
                        csv.Context.RegisterClassMap<ColaboradorMap>();
                        var colaboradores = csv.GetRecords<Colaborador>().ToList().Distinct().ToList();

                        // Inner left anti join usando LINQ
                        // Somente novos colaboradores
                        colaboradores = colaboradores
                         .Where(colabNew => !_context.Colaboradores.Any(colab => colabNew.Codigo == colab.Codigo))
                         .Select(colabNew => new Colaborador
                         {
                             Codigo = colabNew.Codigo,
                             Nome = colabNew.Nome,
                             Departamento = departamento,
                         })
                         .ToList();

                        //Salvar
                        if (colaboradores.IsNullOrEmpty() == false)
                        {
                            _context.Colaboradores.AddRange(colaboradores);
                            _context.SaveChanges();
                        }


                    }
                    #endregion


                    #region  Salvar TempoTrabalhado
                    using (Stream stream = file.OpenReadStream())
                    using (var csv = new CsvReader(new StreamReader(stream), configuration))
                    {
                        csv.Context.RegisterClassMap<TempoTrabalhadoMap>();
                        var tempoTrabalhados = csv.GetRecords<TempoTrabalhado>().ToList().Distinct().ToList();

                        // Inner left anti join usando LINQ
                        // Somente novos tempoTrabalhados
                        tempoTrabalhados = tempoTrabalhados
                         .Where(tempTrabNew => !_context.TempoTrabalhado.Any(tempTrab => tempTrab.Data == tempTrabNew.Data))
                         .Select(tempTrabNew => new TempoTrabalhado
                         {
                             Data = tempTrabNew.Data,
                             Colaborador = tempTrabNew.Colaborador,
                             Entrada = tempTrabNew.Entrada,
                             Saida = tempTrabNew.Saida,
                             AlmocoInic = tempTrabNew.AlmocoInic,
                             AlmocoFim = tempTrabNew.AlmocoFim,
                             ValorHora = tempTrabNew.ValorHora
                         })
                         .ToList();

                        //Salvar
                        if (tempoTrabalhados.IsNullOrEmpty() == false)
                        {
                            _context.TempoTrabalhado.AddRange(tempoTrabalhados);
                            _context.SaveChanges();
                        }


                    }
                    #endregion
                }
            }
        }

    }
}
