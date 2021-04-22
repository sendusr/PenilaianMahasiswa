using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PenilaianMahasiswa
{
    class Mahasiswa
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<MatKul> MatKuls { get; set; }
     
        public Mahasiswa(string id, string name)
        {
            Id = id;
            Name = name;
            MatKuls = new List<MatKul>();

        }

        //public Mahasiswa(string id, string name, List<MatKul> matKuls)
        //{
        //    Id = id;
        //    Name = name;
        //    MatKuls = matKuls;
        //}
    }
}
