using Switch.Domain.Enums;

namespace Switch.Domain.Entities
{
    public class StatusRelacionamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        
        public bool NaoEspecificado
        {
            get { return Id == (int) StatusRelacionamentoEnum.NaoEspecificado; }
        }
        public bool Solteiro
        {
            get { return Id == (int) StatusRelacionamentoEnum.Solteiro; }
        }
        public bool EmRelacionamentoSerio
        {
            get { return Id == (int) StatusRelacionamentoEnum.EmRelacionamentoSerio; }
        }
        public bool Casado
        {
            get { return Id == (int) StatusRelacionamentoEnum.Casado; }
        }
       
    }
}