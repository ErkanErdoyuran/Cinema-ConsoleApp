using System;

namespace ButikSinemaSalonu_G019
{
    class Sinema
    {
        public string FilmAdi { get; }
        public int Kapasite { get; }
        public float TamBiletFiyati { get; }
        public float YarimBiletFiyati { get; }
        public int ToplamTamBiletAdedi { get; private set; }
        public int ToplamYarimBiletAdedi { get; private set; }
        public float Ciro
        {
            get
            {
                return this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
            }
        }


        public Sinema(string filmAdi, int kapasite, float tamBiletFiyati, float yarimBiletFiyati)
        {
            FilmAdi = filmAdi;
            this.Kapasite = kapasite;
            this.TamBiletFiyati = tamBiletFiyati;
            this.YarimBiletFiyati = yarimBiletFiyati;
        }


        //Eğer class'a ait özellikleri (verileri) değiştiriyorsak,
        //bunu metodlarla yapalım
        public void BiletSatis(int tamBiletAdedi, int yarimBiletAdedi)
        {
            //eğer satmak istediğim bilet adetlerinin toplamı
            //boş koltuk adedinden azsa satış yapabilirim

            if ((tamBiletAdedi + yarimBiletAdedi) <= this.BosKoltukAdediGetir())
            {
                this.ToplamTamBiletAdedi += tamBiletAdedi;
                this.ToplamYarimBiletAdedi += yarimBiletAdedi;
                //  CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Yeterli koltuk yok. Boş koltuk adedi: " + this.BosKoltukAdediGetir());
            }
        }

        public void BiletIadesi(int tamBiletAdedi, int yarimBiletAdedi)
        {
            if (tamBiletAdedi <= this.ToplamTamBiletAdedi && yarimBiletAdedi <= this.ToplamYarimBiletAdedi)
            {
                this.ToplamTamBiletAdedi -= tamBiletAdedi;
                this.ToplamYarimBiletAdedi -= yarimBiletAdedi;
                //   CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("İşlem gerçekleştirilemedi.");
                Console.WriteLine("Bu kadar bilet satılmamış.");
            }
        }
        public void BiletIadesiAlternatif(int tamBiletAdedi, int yarimBiletAdedi)
        {
            if (tamBiletAdedi > this.ToplamTamBiletAdedi || yarimBiletAdedi > this.ToplamYarimBiletAdedi)
            {
                Console.WriteLine("İşlem gerçekleştirilemedi.");
                Console.WriteLine("Bu kadar bilet satılmamış.");
            }
            else
            {
                this.ToplamTamBiletAdedi -= tamBiletAdedi;
                this.ToplamYarimBiletAdedi -= yarimBiletAdedi;
                //   CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
        }


        //private void CiroHesapla()
        //{
        //    //Ciroyu hesaplamak için güncel toplam bilet adetlerini kullandım.
        //  //  this.Ciro = this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
        //}


        //int tipinden boş koltuk adedini döndürsün

        public int BosKoltukAdediGetir()
        {
            return this.Kapasite - this.ToplamTamBiletAdedi - this.ToplamYarimBiletAdedi;
        }



    }
}
