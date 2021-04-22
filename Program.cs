using System;
using System.Collections.Generic;
using System.Linq;
namespace PenilaianMahasiswa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mahasiswa> M = new List<Mahasiswa>();
            List<MatKul> matkuls = new List<MatKul>();
            
            Console.Clear();
            while (true)
            {
                ShowMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (option)
                {
                    case 1:
                        AddMhs(M);
                        break;
                    case 2:
                        if (M.Count == 0)
                            Console.WriteLine("Data masih kosong!");
                        else
                            TampilMahasiswa(M);
                        break;
                    case 3:
                        AddMataKuliah(M);

                        break;
                    case 4:
                        DisplayNilai(M);

                        break;


                    default:
                        continue;

                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("=====Menu======");
            Console.WriteLine("1. Add Mahasiswa");
            Console.WriteLine("2. Display MHS");
            Console.WriteLine("3. Add MK");
            Console.WriteLine("4. Display Nilai");
        }

        private static void DisplayNilai(List<Mahasiswa> M)
        {
            if (M.Count == 0)
                Console.WriteLine("Data mahasiswa masih kosong!");
            else
            {
                TampilMahasiswa(M);
                Console.WriteLine("Masukan ID Mahasiswa: (Hint: mcc-xx)");
                string pilihdata2 = Console.ReadLine();
                //if (matkuls.Count==0) // nah ini merujuk pada line 61, tadinya kalau bisa di cek list MK mahasiswa tsb kosong
                // maunya di kasih warning gini:                   
                //   Console.WriteLine("Mahasiswa ini belum mendaftarkan pada matkul apapun!");
                // tapi count matkuls akan selalu 0, padahal udah di isi ¯\_(ツ)_/¯
                try
                {
                    int index2 = M.FindIndex(a => a.Id.Equals(pilihdata2, StringComparison.InvariantCultureIgnoreCase));
                    List<MatKul> matkuls2 = new List<MatKul>();
                    Mahasiswa penampungMKst = M.ElementAt(index2);
                    matkuls2 = penampungMKst.MatKuls;
                    Console.WriteLine($"\nID Mahasiswa : {penampungMKst.Id}");
                    Console.WriteLine($"Nama Mahasiswa : {penampungMKst.Name}");
                    Console.WriteLine("===============Daftar Nilai==============");
                    foreach (MatKul mkt in matkuls2)
                    {


                        Console.WriteLine($"Mata Kuliah : {mkt.NamaMK}");
                        Console.WriteLine($"Nilai : {mkt.Nilai}\n");

                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Data tidak ditemukan, mohon inputkan sesuai ID mahasiswa (Hint: mcc-xx)");
                }
            }
        }

        private static void AddMataKuliah(List<Mahasiswa> M)
        {
            if (M.Count == 0)
                Console.WriteLine("Data mahasiswa masih kosong!");
            else
            {
                TampilMahasiswa(M);
                Console.WriteLine("Masukan ID Mahasiswa: (Hint: mcc-xx)");
                string pilihdata = Console.ReadLine();
                try
                {
                    int index = M.FindIndex(a => a.Id.Equals(pilihdata, StringComparison.InvariantCultureIgnoreCase));

                    Mahasiswa penampungMKs = M.ElementAt(index);
                    Console.WriteLine("\n-----Input Matakuliah untuk mahasiswa (" + penampungMKs.Id + "/" + penampungMKs.Name + ")-------\n");
                    Console.WriteLine("Masukan Matakuliah: ");
                    string mk = Console.ReadLine();
                    Console.WriteLine("Masukan Nilai " + mk + ": ");
                    try
                    {
                        double nilai = Convert.ToDouble(Console.ReadLine());
                        penampungMKs.MatKuls.Add(new MatKul(mk, nilai));
                        // var s = M[2].Count;// disini saya mau coba untuk menampilkan size matakuliah didalam list mahasiswa tapi gk tau gmn caranya
                        // M.Sum(x => x.Count());       karna kalau matkuls.count itu malah 0 padahal udah terisi
                        //Console.WriteLine(s);
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("ERRORR!!!!!!!!!!!INPUTAN SALAH!!! Nilai berupa bilangan desimal");
                        Console.WriteLine("Matakuliah ("+mk+") tidak jadi terinput");
                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("Data tidak ditemukan, mohon inputkan sesuai ID mahasiswa (Hint: mcc-xx)");
                }
            }
        }

        private static void AddMhs(List<Mahasiswa> M)
        {
            int sizeoflist = M.Count;
            Console.WriteLine("Masukan Nama: ");
            string name = Console.ReadLine();
            string IdPanjang = "MCC-4" + (sizeoflist + 1); //id mahasiswa auto generate
            M.Add(new Mahasiswa(IdPanjang, name));
            Console.WriteLine("ID mahasiswa : " + IdPanjang);
            Console.WriteLine("Nama Maasiswa : " + name);
            Console.WriteLine("===========Tambah data berhasil!========\n");
        }

        private static void TampilMahasiswa(List<Mahasiswa> M)
        {
            Console.WriteLine("Data Mahasiswa : \n");
            foreach (Mahasiswa mahasiswa in M)
            {
                Console.WriteLine($"ID: {mahasiswa.Id}");
                Console.WriteLine($"Name: {mahasiswa.Name}\n");

            }
        }
    }
}
