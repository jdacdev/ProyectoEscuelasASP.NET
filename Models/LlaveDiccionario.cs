namespace HolaMundoMVC.Models
{
    public struct LlaveDiccionario
    {
        public const string ESCUELAS = "escuelas";
        public const string CURSOS = "cursos";
        public const string ASIGNATURAS = "asignaturas";
        public const string ALUMNOS = "alumnos";
        public const string EVALUACIONES = "evaluaciones";
    }
    public enum LlaveDiccionarioEnum
    {
        ESCUELAS,
        CURSOS,
        ASIGNATURAS,
        ALUMNOS,
        EVALUACIONES
    }
}