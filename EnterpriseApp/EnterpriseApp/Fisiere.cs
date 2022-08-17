﻿using System;
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
        public const string DenumireFisier1 = "locuri.txt";

        public const string DenumireFisier2 = "variables.txt";

        public static void UpdateFisierLocuri()
        {
            string jsonString = JsonSerializer.Serialize<Loc[]>(Date.Locuri, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(DenumireFisier1, jsonString);
        }

        public static void UpdateFisierVariables()
        {
            int[] variables = new int[4] { Date.PretIntreg, Date.PretIntreg3D, Date.PretRedus, Date.PretRedus3D };

            string jsonString = JsonSerializer.Serialize<int[]>(variables, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(DenumireFisier2, jsonString);
        }

        public static void CitireDinFisier()
        {
            string jsonString = File.ReadAllText(DenumireFisier1);
            Date.Locuri = JsonSerializer.Deserialize<Loc[]>(jsonString);

            jsonString = File.ReadAllText(DenumireFisier2);
            int[] variabile = JsonSerializer.Deserialize<int[]>(jsonString);

            Date.PretIntreg = variabile[0];
            Date.PretIntreg3D = variabile[1];
            Date.PretRedus = variabile[2];
            Date.PretRedus3D = variabile[3];
        }

    }
}
