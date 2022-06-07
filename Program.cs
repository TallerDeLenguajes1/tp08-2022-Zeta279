namespace TrabajoPractico8{
    class Program{
        static void Main(string[] args){
            string path;
            List<string> archivos = new List<string>();

            Console.WriteLine("Ingrese una ruta: ");
            path = Console.ReadLine();

            if(Directory.Exists(path)){
                archivos = Directory.GetFiles(path).ToList();

                foreach(string s in archivos){
                    Console.WriteLine(s);
                }
            }
            else{
                Console.WriteLine("La ruta ingresada no existe");
            }

            
        }
    }
}