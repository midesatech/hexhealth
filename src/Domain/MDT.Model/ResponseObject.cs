namespace MDT.Model
{
    public class ResponseObject
    {
        public readonly Empleado empleado;

        public ResponseObject(Empleado empleado)
        {
            this.empleado = empleado;   
        }

        public static ResponseObject Build(Empleado empleado)
        {
            return new ResponseObject(empleado);
        }
    }
}