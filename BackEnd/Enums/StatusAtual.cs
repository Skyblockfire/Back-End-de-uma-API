using System.ComponentModel;

namespace BackEnd.Enums
{
    public enum StatusAtual
    {
        [Description("Inativo")]
        Inativo = 0,
        [Description("Pendente")]
        Pendente = 1,
        [Description("Ativo")]
        Ativo = 2
    }
}
