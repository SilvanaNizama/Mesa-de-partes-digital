namespace mesadepartes
{
    public static class GestorExpedientes
    {
        // Un arreglo por cada dato 
        public const int MAX = 100;
        public static string[] codigos = new string[MAX];
        public static string[] dnis = new string[MAX];
        public static string[] nombres = new string[MAX];
        public static string[] apellidos = new string[MAX];
        public static string[] tipos = new string[MAX];
        public static string[] asuntos = new string[MAX];
        public static string[] fechas = new string[MAX];

        // Cantidad de expedientes registrados 
        public static int cont = 0;

        // Devuelve true si ningún campo obligatorio está vacío
        public static bool CamposCompletos(string codigo, string dni, string nombre,
                                    string apellido, string tipo, string asunto)
        {
            if (codigo == "" || dni == "" || nombre == "" ||
                apellido == "" || tipo == "" || asunto == "")
            {
                return false;
            }
            return true;
        }

        // Devuelve true si el DNI tiene 8 caracteres y todos son dígitos
        public static bool DniValido(string dni)
        {
            if (dni.Length != 8)
            {
                return false;
            }
            for (int i = 0; i < dni.Length; i++)
            {
                if (dni[i] < '0' || dni[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        // Búsqueda secuencial: devuelve la posición del código, o -1 si no existe
        public static int BuscarPorCodigo(string codigo)
        {
            for (int i = 0; i < cont; i++)
            {
                if (codigos[i] == codigo)
                {
                    return i;
                }
            }
            return -1;
        }

        // Guarda un expediente en la siguiente posición libre
        public static bool Registrar(string codigo, string dni, string nombre, string apellido,
                               string tipo, string asunto, string fecha)
        {
            if (cont >= MAX)
            {
                return false; // el arreglo está lleno
            }
            codigos[cont] = codigo;
            dnis[cont] = dni;
            nombres[cont] = nombre;
            apellidos[cont] = apellido;
            tipos[cont] = tipo;
            asuntos[cont] = asunto;
            fechas[cont] = fecha;
            cont++;
            return true;
        }

        // Intercambia de lugar los datos de dos expedientes (en todos los arreglos)
        public static void Intercambiar(int i, int j)
        {
            // TODO
        }

        // Ordenamiento burbuja por código, usando Intercambiar
        public static void OrdenarBurbuja()
        {
            // TODO
        }

        public static void GuardarEnArchivo() { /* TODO */ }
        public static void CargarDesdeArchivo() { /* TODO */ }
    }
}