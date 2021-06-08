namespace Test_GISSA.Entidades
{
    public class test_Usuario
    {
        public int Id { set; get; }
        public string Tipo_Usuario { set; get; }
        public string Cedula { set; get; }
        public string Tipo_Identificacion { set; get; }
        public string Nombre { set; get; }
        public string Nombre_Usuario { set; get; }
        public string Clave { set; get; }
        public string Correo { set; get; }

        public test_Usuario()
        {
        }

        public test_Usuario(int id,string cedula, string tipo_Usuario, string tipo_Identificacion, string nombre, string nombre_Usuario, string correo) 
        {
            Id = id;
            Cedula = cedula;
            Tipo_Usuario = tipo_Usuario;
            Tipo_Identificacion = tipo_Identificacion;
            Nombre = nombre;
            Nombre_Usuario = nombre_Usuario;
            Correo = correo;
        }
        public test_Usuario(int id, string cedula, string tipo_Usuario, string tipo_Identificacion, string nombre, string nombre_Usuario, string clave, string correo)
        {
            Id = id;
            Cedula = cedula;
            Tipo_Usuario = tipo_Usuario;
            Tipo_Identificacion = tipo_Identificacion;
            Nombre = nombre;
            Nombre_Usuario = nombre_Usuario;
            Clave = clave;
            Correo = correo;
        }
        public test_Usuario(string cedula, string tipo_Usuario, string tipo_Identificacion, string nombre, string nombre_Usuario,string clave, string correo)
        {
            Cedula = cedula;
            Tipo_Usuario = tipo_Usuario;
            Tipo_Identificacion = tipo_Identificacion;
            Nombre = nombre;
            Nombre_Usuario = nombre_Usuario;
            Clave = clave;
            Correo = correo;
        }
        public test_Usuario(string nombre_Usuario, string clave)
        {
            Nombre_Usuario = nombre_Usuario;
            Clave = clave;
        }

        
    }
}
