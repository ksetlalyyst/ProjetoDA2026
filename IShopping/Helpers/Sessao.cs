namespace iShopping.Helpers
{
    public static class Sessao
    {
        public static int UtilizadorId { get; set; }
        public static string Username { get; set; }
        public static string NomeCompleto { get; set; }

        public static void Limpar()
        {
            UtilizadorId = 0;
            Username = null;
            NomeCompleto = null;
        }

        public static bool EstaLogado => UtilizadorId > 0;
    }
}
