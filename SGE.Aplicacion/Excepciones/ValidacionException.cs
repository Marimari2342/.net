namespace SGE.Aplicacion;

public class ValidacionException : Exception
//Es lanzada cuando una entidad no cumple con los requisitos exigidos y no supera la validación establecida ¿¿¿????
{
    public ValidacionException(string message) : base(message) { }   
}
