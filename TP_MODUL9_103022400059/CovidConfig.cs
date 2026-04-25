using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400059
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
        private string filePath = "covid_config.json";

        public CovidConfig()
        {

        }

        public void Load()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    CovidConfig config = JsonSerializer.Deserialize<CovidConfig>(json);

                    this.satuan_suhu = config.satuan_suhu;
                    this.batas_hari_deman = config.batas_hari_deman;
                    this.pesan_ditolak = config.pesan_ditolak;
                    this.pesan_diterima = config.pesan_diterima;
                }
                else
                {
                    SetDefault();
                    Save();
                }
            }
            catch (Exception)
            {
                SetDefault();
            }
        }

        public void SetDefault()
        {
            satuan_suhu = "celcius";
            batas_hari_deman = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu.ToLower() == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }

            Save();
        }
    }
}
