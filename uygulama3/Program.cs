using System;
using System.Collections.Generic;
using System.Linq;

class Ekipman
{
    public int DemirbasNo;
    public string Ad;
    public bool OduncteMi;

    public Ekipman(int no, string ad)
    {
        DemirbasNo = no;
        Ad = ad;
        OduncteMi = false;
    }
}

class Ogrenci
{
    public int OgrenciNo;
    public string AdSoyad;

    public Ogrenci(int no, string ad)
    {
        OgrenciNo = no;
        AdSoyad = ad;
    }
}

class Program
{
    static List<Ekipman> ekipmanlar = new List<Ekipman>();
    static List<Ogrenci> ogrenciler = new List<Ogrenci>();

    static void Main(string[] args)
    {
        ekipmanlar.Add(new Ekipman(101, "Bilgisayar"));
        ekipmanlar.Add(new Ekipman(102, "Projeksiyon"));
        ekipmanlar.Add(new Ekipman(103, "Tablet"));

        ogrenciler.Add(new Ogrenci(1, "Ahmet Yilmaz"));
        ogrenciler.Add(new Ogrenci(2, "Ayse Demir"));

        Ekipman e = EkipmanBul(101);

        if (e != null)
            Console.WriteLine("Bulunan ekipman: " + e.Ad);

        Console.WriteLine("\n--- ODUNC VERME ---");
        OduncVer(1, 101);
        OduncVer(2, 101);

        Console.WriteLine("\n--- IADE ISLEMI ---");
        IadeAl(101);
        IadeAl(101);

        Console.WriteLine("\n--- BULUNAMAYAN KAYITLAR ---");
        OduncVer(99, 102);
        OduncVer(1, 999);

        Console.ReadLine();
    }

    static Ekipman EkipmanBul(int no)
    {
        return ekipmanlar.FirstOrDefault(x => x.DemirbasNo == no);
    }

    static Ogrenci OgrenciBul(int no)
    {
        return ogrenciler.FirstOrDefault(x => x.OgrenciNo == no);
    }

    static void OduncVer(int ogrenciNo, int demirbasNo)
    {
        Ogrenci o = OgrenciBul(ogrenciNo);
        Ekipman e = EkipmanBul(demirbasNo);

        if (o == null)
        {
            Console.WriteLine("Ogrenci bulunamadi!");
            return;
        }

        if (e == null)
        {
            Console.WriteLine("Ekipman bulunamadi!");
            return;
        }

        if (e.OduncteMi)
        {
            Console.WriteLine("Ekipman zaten odunc verilmis!");
            return;
        }

        e.OduncteMi = true;
        Console.WriteLine(o.AdSoyad + ", " + e.Ad + " ekipmanini odunc aldi.");
    }

    static void IadeAl(int demirbasNo)
    {
        Ekipman e = EkipmanBul(demirbasNo);

        if (e == null)
        {
            Console.WriteLine("Ekipman bulunamadi!");
            return;
        }

        if (!e.OduncteMi)
        {
            Console.WriteLine("Ekipman zaten iade edilmis!");
            return;
        }

        e.OduncteMi = false;
        Console.WriteLine(e.Ad + " basariyla iade alindi.");
    }
}