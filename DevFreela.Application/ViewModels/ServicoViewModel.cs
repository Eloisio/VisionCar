namespace VisionCar.Application.ViewModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel(int id, int idEmpresa, string descricao, decimal preco, bool aivo)
        {
            Id = id;
            Id=idEmpresa;
            Descricao = descricao;
            Preco= preco;
            Ativo= aivo;

        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
