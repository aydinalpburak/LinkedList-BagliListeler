using System;

namespace baglilist2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Baslıyoruz");
            Listele listele = new Listele();
            listele.add(5,"burak","matematik");
            listele.add(10,"Mehmet","fen");
            listele.add(15,"enes","edebiyat");
            listele.list();
            Console.WriteLine(listele.capacity());
            listele.delete(15);
            Console.WriteLine("Delete Yapıldı");
            listele.list();
            Console.WriteLine(listele.capacity());

        }
    }
    class Bilgi
    {
        public int veri;
        public string isim;
        public string ders;
        public Bilgi sonraki;
        public Bilgi önceki;
        public Bilgi(int veri, string isim, string ders)
        {
            this.veri = veri;
            this.isim = isim;
            this.ders = ders;
        }

    }
    class Listele
    {
        Bilgi ilk=null;
        Bilgi son=null;
        public void add(int veri,string isim,string ders)
        {
            Bilgi bilgi = new Bilgi(veri,isim,ders);
            if (ilk==null)
            {
                ilk = bilgi;
                son = bilgi;
                son.sonraki = null;
            }
            else
            {
                son.sonraki = bilgi;
                son = bilgi;        
            }
        }
        public void list()
        {
            Bilgi gecici = ilk;
            while (gecici!=null)
            {
                Console.WriteLine(gecici.veri+" "+gecici.isim+" "+gecici.ders);
                gecici = gecici.sonraki;
            }
        }
        public void delete(int no)
        {
            Bilgi gecici = ilk; Bilgi bironceki=ilk;
            while (gecici!=null)
            {
                if (no==gecici.veri)
                {
                    break;
                }
                bironceki = gecici;
                gecici = gecici.sonraki;
            }
            if (gecici == null)
            {
                Console.WriteLine("Bulunumadı");
            }
            {
                if (son==ilk)
                {
                    ilk = null;
                    son = null;
                }
                else
                {
                    if (gecici==ilk)
                    {
                        ilk = gecici.sonraki;
                    }
                    else
                    {
                        if (gecici==son)
                        {
                            son = bironceki;
                            bironceki.sonraki = null;
                        }
                        else
                        {
                            bironceki.sonraki = gecici.sonraki;
                        }
                    }
                }
            }
        }
        public int capacity()
        {
            Bilgi gecici = ilk;
            int i=0;
            while (gecici!=null)
            {
                i++;
                gecici = gecici.sonraki;
            }
            return i;
        }

    }
}
