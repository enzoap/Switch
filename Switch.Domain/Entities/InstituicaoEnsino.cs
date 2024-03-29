using System;

namespace Switch.Domain.Entities
{
    public class InstituicaoEnsino
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public DateTime? AnoFormacao { get; set; }
    }
}