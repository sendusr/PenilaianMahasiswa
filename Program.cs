using System;
using System.Collections.Generic;
using System.Linq;
namespace PenilaianMahasiswa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mahasiswa> m = new List<Mahasiswa>();
            List<MatKul> matkuls = new List<MatKul>();

            Console.Clear();
            ShowSelection(m);
        }

        private static void ShowMenu()
        {
            Console.WriteLine("=====Menu======");
            Console.WriteLine("1. Add Mahasiswa");
            Console.WriteLine("2. Display MHS");
            Console.WriteLine("3. Add MK");
            Console.WriteLine("4. Display Nilai");
        }
        private static void ShowSelection(List<Mahasiswa> m)
        {
            while (true)
            {
                ShowMenu();

                try
                {
                    int option = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            AddMhs(m);
                            break;
                        case 2:
                            if (m.Count == 0)
                                Console.WriteLine("Data masih kosong!");
                            else
                                TampilMahasiswa(m);
                            break;
                        case 3:
                            AddMataKuliah(m);

                            break;
                        case 4:
                            DisplayNilai(m);
                            break;
                        default:
                            continue;

                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Inputan menu salah!");
                }

            }
        }

        

        private static void DisplayNilai(List<Mahasiswa> m)
        {
            if (m.Count == 0)
                Console.WriteLine("Data mahasiswa masih kosong!");
            else
            {
                TampilMahasiswa(m);
                Console.WriteLine("Masukan ID Mahasiswa: (Hint: mcc-xx)");
                string pilihdata2 = Console.ReadLine();

                    try
                    {
                        int index2 = m.FindIndex(a => a.Id.Equals(pilihdata2, StringComparison.InvariantCultureIgnoreCase));
                        List<MatKul> matkuls2 = new List<MatKul>();
                        Mahasiswa penampungMKst = m.ElementAt(index2);
                        matkuls2 = penampungMKst.MatKuls;
                    if (penampungMKst.MatKuls.Count() == 0)
                    {
                        Console.WriteLine("Mahasiswa ini belum mendaftarkan matakuliah: ");
                        Console.WriteLine($"ID Mahasiswa : {penampungMKst.Id}");
                        Console.WriteLine($"Nama Mahasiswa : {penampungMKst.Name}\n");
                    }
                        
                    else
                    {
                        Console.WriteLine($"\nID Mahasiswa : {penampungMKst.Id}");
                        Console.WriteLine($"Nama Mahasiswa : {penampungMKst.Name}");
                        Console.WriteLine("===============Daftar Nilai==============");
                        foreach (MatKul mkt in matkuls2)
                        {


                            Console.WriteLine($"Mata Kuliah : {mkt.NamaMK}");
                            Console.WriteLine($"Nilai : {mkt.Nilai}\n");

                        }
                    }
                        
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Data tidak ditemukan, mohon inputkan sesuai ID mahasiswa (Hint: mcc-xx)");
                    }
            }
        }

        private static void AddMataKuliah(List<Mahasiswa> m)
        {
            if (m.Count == 0)
                Console.WriteLine("Data mahasiswa masih kosong!");
            else
            {
                TampilMahasiswa(m);
                Console.WriteLine("Masukan ID Mahasiswa: (Hint: mcc-xx)");
                string pilihdata = Console.ReadLine();
                try
                {
                    int index = m.FindIndex(a => a.Id.Equals(pilihdata, StringComparison.InvariantCultureIgnoreCase));

                    Mahasiswa penampungMKs = m.ElementAt(index);
                    Console.WriteLine("\n-----Input Matakuliah untuk mahasiswa (" + penampungMKs.Id + "/" + penampungMKs.Name + ")-------\n");
                    Console.WriteLine("Masukan Matakuliah: ");
                    string mk = Console.ReadLine();
                    Console.WriteLine("Masukan Nilai " + mk + ": ");
                    try
                    {
                        double nilai = Convert.ToDouble(Console.ReadLine());
                        penampungMKs.MatKuls.Add(new MatKul(mk, nilai));
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

        private static void AddMhs(List<Mahasiswa> m)
        {
            int sizeoflist = m.Count;
            Console.WriteLine("Masukan Nama: ");
            string name = Console.ReadLine();
            string idPanjang = "MCC-4" + (sizeoflist + 1); //id mahasiswa auto generate
            m.Add(new Mahasiswa(idPanjang, name));
            Console.WriteLine("ID mahasiswa : " + idPanjang);
            Console.WriteLine("Nama Maasiswa : " + name);
            Console.WriteLine("===========Tambah data berhasil!========\n");
        }

        private static void TampilMahasiswa(List<Mahasiswa> m)
        {
            Console.WriteLine("Data Mahasiswa : \n");
            foreach (Mahasiswa mahasiswa in m)
            {
                Console.WriteLine($"ID: {mahasiswa.Id}");
                Console.WriteLine($"Name: {mahasiswa.Name}\n");

            }
        }
    }
}
