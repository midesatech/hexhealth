namespace MDT.Model
{
    public class Empleado
    {
        public string Codigo {get; private set;}
        public string Nombre {get; private set;}
        public string Apellido {get; private set;}

        public Empleado (string codigo, string nombre, string apellido)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

    }
}