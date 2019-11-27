using System;

namespace Switch.Domain.Entities
{
    public class UsuarioGrupo
    {
        
        
        public DateTime DataCriacao { get; set; }
        public bool EhAddministrador { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}