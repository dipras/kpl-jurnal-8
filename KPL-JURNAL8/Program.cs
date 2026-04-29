using System;
using KPL_JURNAL8;

namespace KPL_JURNAL8
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig config = new BankTransferConfig();

            if (config.conf.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (config.conf.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }

            int amount = Convert.ToInt32(Console.ReadLine());
            int threshold = Convert.ToInt32(config.conf.transfer.threshold);
            int low_fee = Convert.ToInt32(config.conf.transfer.low_fee);
            int high_fee = Convert.ToInt32(config.conf.transfer.high_fee);

            int fee = amount <= threshold ? low_fee : high_fee;
            int total = amount + fee;

            if (config.conf.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {fee}");
                Console.WriteLine($"Total amount = {total}");
                Console.WriteLine("Select transfer method:");
            }
            else if (config.conf.lang == "id")
            {
                Console.WriteLine($"Biaya transfer = {fee}");
                Console.WriteLine($"Total biaya = {total}");
                Console.WriteLine("Pilih metode transfer:");
            }

            for (int i = 0; i < config.conf.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.conf.methods[i]}");
            }

            string method = Console.ReadLine();

            if (config.conf.lang == "en")
            {
                Console.WriteLine($"Please type \"{config.conf.confirmation.en}\" to confirm the transaction:");
            }
            else if (config.conf.lang == "id")
            {
                Console.WriteLine($"Ketik \"{config.conf.confirmation.id}\" untuk mengkonfirmasi transaksi:");
            }

            string confirm = Console.ReadLine();

            if (config.conf.lang == "en")
            {
                if (confirm == config.conf.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (config.conf.lang == "id")
            {
                if (confirm == config.conf.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}
