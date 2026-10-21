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
        public static void Intercambiar(int i, int j)
        {
            string temp;
            temp = codigos[i]; codigos[i] = codigos[j]; codigos[j] = temp;
            temp = dnis[i]; dnis[i] = dnis[j]; dnis[j] = temp;
            temp = nombres[i]; nombres[i] = nombres[j]; nombres[j] = temp;
            temp = apellidos[i]; apellidos[i] = apellidos[j]; apellidos[j] = temp;
            temp = tipos[i]; tipos[i] = tipos[j]; tipos[j] = temp;
            temp = asuntos[i]; asuntos[i] = asuntos[j]; asuntos[j] = temp;
            temp = fechas[i]; fechas[i] = fechas[j]; fechas[j] = temp;
        }

        public static void OrdenarBurbuja()
        {
            for (int i = 0; i < cont - 1; i++)
            {
                for (int j = 0; j < cont - 1 - i; j++)
                {
                    if (string.Compare(codigos[j], codigos[j + 1]) > 0)
                    {
                        Intercambiar(j, j + 1);
                    }
                }
            }
        }
        public static void GuardarEnArchivo()
        {
            string[] lineas = new string[cont];
            for (int i = 0; i < cont; i++)
            {
                lineas[i] = codigos[i] + "|" + dnis[i] + "|" + nombres[i] + "|" +
                            apellidos[i] + "|" + tipos[i] + "|" + asuntos[i] + "|" + fechas[i];
            }
            System.IO.File.WriteAllLines("expedientes.txt", lineas);
        }
        public static void CargarDesdeArchivo()
        {
            if (!System.IO.File.Exists("expedientes.txt"))
            {
                return;
            }
            string[] lineas = System.IO.File.ReadAllLines("expedientes.txt");
            cont = 0;
            foreach (string linea in lineas)
            {
                string[] d = linea.Split('|');
                if (d.Length == 7 && cont < MAX)
                {
                    codigos[cont] = d[0];
                    dnis[cont] = d[1];
                    nombres[cont] = d[2];
                    apellidos[cont] = d[3];
                    tipos[cont] = d[4];
                    asuntos[cont] = d[5];
                    fechas[cont] = d[6];
                    cont++;
                }
            }
        }
    }
}