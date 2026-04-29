# Dokumentasi KPL-JURNAL8

## 1. Implementasi BankTransferConfig.cs
Class ini bertanggung jawab untuk membaca dan menyimpan konfigurasi program dari file `bank_transfer_config.json`. Apabila file tidak ada, class ini akan membuat menggunakan nilai default.

```csharp
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
// ...
```

## 2. Program Utama
Bagian ini mengambil input dari pengguna dan mencocokannya dengan konfigurasi yang ada. Program menggunakan JSON file config dengan key `lang` untuk menentukan bahasa yang akan digunakan (id atau en).

```csharp
            if (config.conf.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (config.conf.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }
```

## 3. Hasil Run
Program berhasil membaca input dan menghasilkan respon berdasarkan `bank_transfer_config.json` melalui runtime configuration:

```
Please insert the amount of money to transfer:
2000000
Transfer fee = 6500
Total amount = 2006500
Select transfer method:
1. RTO (real-time)
2. SKN
3. RTGS
4. BI FAST
1
Please type "yes" to confirm the transaction:
yes
The transfer is completed
```

Cukup tekan *Run* atau *Start Debugging* melalui Visual Studio untuk mencoba, atau menggunakan Command Prompt di Windows Desktop dengan sintaks `dotnet run` pada direktori project `KPL-JURNAL8`.

Link GitHub: https://github.com/dipras/kpl-jurnal-8
