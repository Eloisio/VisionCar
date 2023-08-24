namespace VisionCar.Application.ViewModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel(int id, int idEmpresa, string descricao, string preco,  bool aivo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Descricao = descricao;
            Preco= preco;
           // PrecoGD = precodg;
            Ativo= aivo;

        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        //public string PrecoGD { get; set; }
        public bool Ativo { get; set; }
    }
}
