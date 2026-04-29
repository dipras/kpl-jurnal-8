using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace KPL_JURNAL8
{
    public class TransferConfig
    {
        public string threshold { get; set; } = "CONFIG2";
        public string low_fee { get; set; } = "CONFIG3";
        public string high_fee { get; set; } = "CONFIG4";
    }

    public class ConfirmationConfig
    {
        public string en { get; set; } = "CONFIG6";
        public string id { get; set; } = "CONFIG7";
    }

    public class ConfigData
    {
        public string lang { get; set; } = "en";
        public TransferConfig transfer { get; set; } = new TransferConfig();
        public List<string> methods { get; set; } = new List<string>();
        public ConfirmationConfig confirmation { get; set; } = new ConfirmationConfig();
    }

    public class BankTransferConfig
    {
        public ConfigData conf;
        public string filepath = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filepath);
            conf = JsonSerializer.Deserialize<ConfigData>(configJsonData);
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(conf, options);
            File.WriteAllText(filepath, jsonString);
        }

        private void SetDefault()
        {
            conf = new ConfigData();
            conf.lang = "en";
            conf.transfer.threshold = "25000000";
            conf.transfer.low_fee = "6500";
            conf.transfer.high_fee = "15000";
            conf.methods = new List<string>() { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            conf.confirmation.en = "yes";
            conf.confirmation.id = "ya";
        }
    }
}
