namespace UniEstoque.Classes
{
    public class Itens
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Tamanho { get; set; }
        public double Valor { get; set; }
        public string Fornecedor { get; set; }
        public int Status { get; set; }
        public object PersistId { get; internal set; }

        public Itens()
        {
            Id = 0;
            Item = string.Empty;
            Tamanho = string.Empty;
            Valor = 0.0;
            Fornecedor = string.Empty;
            Status = 0;
        }

    }
}
