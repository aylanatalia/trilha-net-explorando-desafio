namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            
            if (Suite.Capacidade >= hospedes.Count() )
            {
                Hospedes = hospedes;
            }
            else
            {
                
                throw new InvalidOperationException($"Não tem vagas suficientes. Capacidade: {Suite.Capacidade}, número de hospedes {hospedes.Count}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            
            return Hospedes?.Count() ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
           
            decimal valor = DiasReservados * Suite.ValorDiaria;

            
            if (DiasReservados >= 10)
            {
                decimal desconto = 0.9m;
                valor *= desconto ;
            }

            return valor;
        }
    }
}