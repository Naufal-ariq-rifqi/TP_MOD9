using System;
using TP_MODUL9_103022400059;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        config.Load();
        config.UbahSatuan();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hari = int.Parse(Console.ReadLine());

        bool suhuValid = false;
        bool hariValid = hari < config.batas_hari_deman;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            suhuValid = (suhu >= 36.5 && suhu <= 37.5);
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            suhuValid = (suhu >= 97.7 && suhu <= 99.5);
        }

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}