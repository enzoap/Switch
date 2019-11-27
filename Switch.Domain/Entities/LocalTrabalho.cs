using System;

namespace Switch.Domain.Entities
{
    public class LocalTrabalho
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataSaida { get; set; }
        public bool EmpresaAtual { get; set; }
        
    }
}