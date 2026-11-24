using System;
using System.Collections;
/*
    Isim Soyisi: Salih Damar,
    Ogrenci No. 1306250046,
    NYP LAB 1.Hafta Odevi
*/
enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    public int Kimlik{get; private set;}
    string Ad;
    CihazTuru Tur;
    public bool AcikMi{get; private set;}

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }
    

    public void Ac()
    {
        AcikMi = true;
        Console.WriteLine("Cihaz Acildi.");
    }

    public void Kapat()
    {
        AcikMi = false;
        Console.WriteLine("Cihaz kapatildi.");
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"Kimlik: {Kimlik}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Cihaz Turu: {Tur}");
        Console.Write($"Durum: ");
        if (AcikMi)
        {
            Console.Write("Acik\n\n");
        }
        else
        {
            Console.Write("Kapali\n\n");
        }

    }
}


class Program
{

    static void Main()
    {
        int userChoice = 1;
        List<Cihaz> AkilliEv = new List<Cihaz>(); 

        Cihaz salonLamba = new Cihaz(001, "Salon Lamba", CihazTuru.Lamba);
        Cihaz salonKlima = new Cihaz(002, "Salon Klima", CihazTuru.Klima);
        Cihaz salonKamera = new Cihaz(003, "Salon Kamera", CihazTuru.GuvenlikSistemi);
        
        AkilliEv.Add(salonLamba);
        AkilliEv.Add(salonKlima);
        AkilliEv.Add(salonKamera);

        while(userChoice != 0)
        {
            Console.WriteLine("=================MENU=================");
            Console.WriteLine("0.Cikis");
            Console.WriteLine("1.Cihazlari Listele");
            Console.WriteLine("2.Cihaz Ekle");
            Console.WriteLine("3.Cihaz Ac");
            Console.WriteLine("4.Cihaz Kapat");

            userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 0:
                    break;
                case 1:
                    foreach (var cihaz in AkilliEv)
                    {
                        cihaz.BilgileriGoster();
                    }
                    break;
            
                case 2:
                    int kimlik;
                    string ad;
                    CihazTuru tur = CihazTuru.Lamba;
                    //Derleyici tur degiskeninin tanimsiz kalabilecegini dusunerek hata verdiginden baslangic degeri verdim.


                    bool kimlikGecerliMi;
                    do
                    {
                        kimlikGecerliMi = true;
                        Console.Write("Cihaz Kimligi(sayi): ");
                        kimlik = int.Parse(Console.ReadLine());
                        foreach (var cihaz in AkilliEv)
                        {
                            if(kimlik == cihaz.Kimlik)
                            {
                                Console.WriteLine("Ayni kimlikte iki cihaz olamaz.");
                                kimlikGecerliMi = false;
                            }
                        }
                    }while(!kimlikGecerliMi);
                    Console.Write("Cihaz Adi: ");
                    ad = Console.ReadLine();
                    bool turGecerliMi = false;
                    while (!turGecerliMi)
                    {
                        Console.Write("Cihaz Turu (0-Lamba, 1-Klima, 2-GuvenlikSistemi): ");
                        int cihazTur = int.Parse(Console.ReadLine());
                        switch (cihazTur)
                        {
                            case 0:
                                tur = CihazTuru.Lamba;
                                turGecerliMi = true;
                                break;
                            case 1:
                                tur = CihazTuru.Klima;
                                turGecerliMi = true;
                                break;
                            case 2:
                                tur = CihazTuru.GuvenlikSistemi;
                                turGecerliMi = true;
                                break;
                            default:
                                Console.WriteLine("Gecersiz Cihaz Turu");
                                break;
                        }
                    }

                    Cihaz c = new Cihaz(kimlik, ad, tur);
                    AkilliEv.Add(c);
                    break;
            
                case 3:
                    cihazBulAcKapa(AkilliEv, true);
                    break;

                case 4:
                    cihazBulAcKapa(AkilliEv, false);
                    break;
                
                default:
                    Console.WriteLine("Gecersiz Secim");
                    break;
            }
        }   
    }

    static void cihazBulAcKapa(List<Cihaz> AkilliEv ,bool acacakMiyiz)
    {
        bool cihazVarMi = false;
        foreach (var cihaz in AkilliEv)
        {
            cihaz.BilgileriGoster();
        }
        Console.WriteLine("Acmak/Kapatmak istediginiz cihazin ID'sini giriniz: ");
        int AcKapaID = int.Parse(Console.ReadLine());
        foreach (var cihaz in AkilliEv)
        {
            if(cihaz.Kimlik == AcKapaID)
            {
                cihazVarMi = true;
                if (acacakMiyiz)
                {
                    cihaz.Ac();      
                }else
                {
                    cihaz.Kapat();
                }
            }
        }
        if (!cihazVarMi)
        {
            Console.WriteLine("Cihaz Bulunamadi");
        }
    }

}