

namespace Test_GISSA.Entidades
{
    public class test_Telefono
    {
       
        public int Id { set; get; }
        public string Numero_Telefono { set; get; }
        public int FK_Id_Usuario { set; get; }

        public test_Telefono(int id, string numero_Telefono, int fK_Id_Usuario)
        {
            Id = id;
            Numero_Telefono = numero_Telefono;
            FK_Id_Usuario = fK_Id_Usuario;
        }
    }
}
