using System.Collections.Generic;

string directorio;

do
{
    Console.WriteLine("Ingrese un path valido: ");
    directorio = Console.ReadLine();
}while(!(Directory.Exists(directorio)));

List<string> Directorios = Directory.GetDirectories(@directorio).ToList();
foreach(string Carpetas in Directorios)
{
    Console.WriteLine(Carpetas);
}

string[] archivos = Directory.GetFiles(directorio);
string NuevoCSV = directorio + @"\reporte_archivos.csv";

using (StreamWriter writer = new StreamWriter(NuevoCSV))
    {
    writer.WriteLine("Nombre del archivo, Tamano KB, Fecha de Modificacion");
    
    foreach(string archivo in archivos)
    {
    FileInfo FileOp = new FileInfo(archivo);
    Console.WriteLine("Nombre del archivo: " + FileOp.FullName);
    Console.WriteLine("Fecha de modificacion: " + FileOp.LastWriteTime);
    Console.WriteLine("Tamano en kb: " + (FileOp.Length / 1024.0).ToString("F2"));
    Console.WriteLine();

    writer.WriteLine(FileOp.Name + "," + ((FileOp.Length / 1024.0).ToString("F2"))+ "," + FileOp.LastWriteTime);

    }
}