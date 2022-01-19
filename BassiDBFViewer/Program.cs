using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BassiDBFViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string adherents = BassiDBFReader.DBFReader.GetDataFromFile(BassiDBFReader.Tables.Adherent);
            Console.WriteLine(adherents);
            Console.ReadLine();
        }
    }
}
