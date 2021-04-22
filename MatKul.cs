using System;
using System.Collections.Generic;
using System.Text;

namespace PenilaianMahasiswa
{
    class MatKul
    {
        public string NamaMK { get; set; }
        public double Nilai { get; set; }


        
       

        public MatKul(string namaMK, double nilai)
        {
            NamaMK = namaMK;
            Nilai = nilai;
        }
    }
}
