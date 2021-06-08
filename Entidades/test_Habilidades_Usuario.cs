namespace Test_GISSA.Entidades
{
    public class test_Habilidades_Usuario : test_Catalogo
    {
        public int FK_Id_Usuario { set; get; }

        public test_Habilidades_Usuario(int id,string nombre_Habilidad,int fK_Id_Usuario)
        {
            Id = id;
            Nombre_Habilidad = nombre_Habilidad;
            FK_Id_Usuario = fK_Id_Usuario;
        }
    }
}
