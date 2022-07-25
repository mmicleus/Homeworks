using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnterpriseApp
{
    public static class Fisiere
    {
        public static void UpdateFisierLocuri()
        {
            string jsonString = JsonSerializer.Serialize<Loc[]>(Date.Locuri, new JsonSerializerOptions { WriteIndented = true });

            //Console.WriteLine(jsonString);

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\locuri.txt", jsonString);

            //Console.ReadLine();
        }

        public static void UpdateFisierVariables()
        {
            int[] variables = new int[4] { Date.PretIntreg, Date.PretIntreg3D, Date.PretRedus, Date.PretRedus3D };

            string jsonString = JsonSerializer.Serialize<int[]>(variables, new JsonSerializerOptions { WriteIndented = true });

            //Console.WriteLine(jsonString);

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\variables.txt", jsonString);
        }

    }
}
