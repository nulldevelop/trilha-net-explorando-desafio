namespace DesafioProjetoHospedagem.Models
{
    public class Reserva(int diasReservados)
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; } = diasReservados;

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new System.Exception(
                    "A capacidade da suite é menor que o número de hóspedes."
                );
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            if (suite != null)
            {
                Suite = suite;
            }
            else
            {
                throw new System.Exception("A suite não pode ser nula.");
            }
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;

            if (DiasReservados >= 10)
            {
                valor = (DiasReservados * Suite.ValorDiaria) * 0.9M;
            }
            else if (DiasReservados < 10)
            {
                valor = DiasReservados * Suite.ValorDiaria;
            }
            else
            {
                valor = 0;
            }

            return valor;
        }
    }
}
