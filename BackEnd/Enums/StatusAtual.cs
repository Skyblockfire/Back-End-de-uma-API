using System.ComponentModel;

namespace BackEnd.Enums
{
    public enum StatusAtual
    {
        [Description("Inativo")]
        Inativo = 0,
        [Description("Ativo")]
        Ativo = 1,
        [Description("Pendente")]
        Pendente = 2
    }
}
