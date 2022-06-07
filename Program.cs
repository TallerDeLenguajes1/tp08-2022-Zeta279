namespace TrabajoPractico8{
    class Program{
        static void Main(string[] args){
            string path, cadena = "";
            List<string> archivos = new List<string>();

            Console.WriteLine("Ingrese una ruta: ");
            path = Console.ReadLine();

            if(Directory.Exists(path)){
                archivos = Directory.GetFiles(path).ToList();

                if(archivos.Count == 0){
                    Console.WriteLine("La ruta ingresada no contiene archivos");
                }
                else{
                    foreach(string s in archivos){
                        Console.WriteLine(s);
                        Console.WriteLine($"Extensión: {Path.GetExtension(s)}");
                    }
                }
                
            }
            else{
                Console.WriteLine("La ruta ingresada no existe");
            }

            Console.Write("\n");

            if(!File.Exists(path + @"\index.csv")){
                Console.WriteLine("Creando archivo index.csv");
                File.Create(path + @"\index.csv");
            }



            for(int i = 0; i < archivos.Count; i++){
                archivos[i] = Path.GetFileName(archivos[i]);
            }

            // Creación del FileStream
            var archivo = new FileStream(path + @"\index.csv", FileMode.Truncate);

            cadena = "ID;NOMBRE;EXTENSION\n";
            for(int i = 0; i < archivos.Count; i++){
                cadena += $"{i + 1};{Path.GetFileNameWithoutExtension(archivos[i])};{Path.GetExtension(archivos[i])}\n";
            }

            StreamWriter escribir = new StreamWriter(archivo);

            escribir.Write(cadena);

            escribir.Close();

            archivo.Close();
            
            
        }
    }
}