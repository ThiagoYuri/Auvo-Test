namespace Auvo.RH.Models.Dto.Analise
{
    public class AnaliseDepartamentoDto
    {

        public string Nome { get; set; }

        public List<AnaliseColaboradorDto> Colaboradores { get; set; }
    }

    public class AnaliseColaboradorDto
    {
        public string Nome { get; set; }

        public List<Colaborador> Colaboradores { get; set; }
    }

}
