using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Odev2._1
{
    public class Bilgi
    {
        public int numara;
        public string ad;
        public double ort;
        public string ders;
        public Bilgi sonraki;
        public Bilgi önceki;
        public Bilgi(int numara,string ad,double ort,string ders)
        {
            this.ad = ad;
            this.ders = ders;
            this.numara = numara;
            this.ort = ort;
        }
    }
    public class Liste 
    {
        Bilgi ilk = null; //ilk ve son değerler belirleniyor
        Bilgi son = null;        
        public void add_bas(int numara, string ad, double ort, string ders)
        {            
                Bilgi bilgi = new Bilgi(numara, ad, ort, ders);
                Bilgi bironceki = ilk, gecici = ilk;
                if (ilk == null)//eğer ilk değer boş ise ilke atıyor 
                {
                    ilk = bilgi;
                    son = bilgi;
                    son.sonraki = null;
                }
                else//listede eleman var ise başa ekleme yapıyor
                {
                    bilgi.sonraki = ilk;
                    ilk = bilgi;
                }                        
        }//başyan bağlı liste ekleme için kullanılan kodlar
        public void add_sira(int numara, string ad, double ort, string ders)
        {
            Bilgi bilgi = new Bilgi(numara, ad, ort, ders);
            try
            {
                son.sonraki = bilgi;
                son = bilgi;
            }
            catch 
            {
                MessageBox.Show("ÖNCE BAŞA EKLEYİNİZ");
            }
        }//sıradan bağlı liste ekleme için kullanılan kodlar
        public void add_son(int numara, string ad, double ort, string ders)
        {
            Bilgi bilgi = new Bilgi(numara, ad, ort, ders);
            try
            {
                son.sonraki = bilgi;
                son = bilgi;
            }
            catch 
            {
                MessageBox.Show("ÖNCE BAŞA EKLEYİNİZ");
                //eğer ilk elaman yok ise hata verdiğinde sistem çökmessin diye yazılmıştır
            }
        }//sondan bağlı liste ekleme için kullanılan kodlar
        public void deleteBAS()//bağlı liste ile baştan silme
        {
            Bilgi gecici = ilk; Bilgi bironceki = ilk;
            if (son == ilk)//eğer listede bir elaman var ise , yani tek ve son ise onu siler.
            {
                ilk = null;
                son = null;
            }
            else
            {
                if (gecici == ilk)
                {
                    ilk = gecici.sonraki;
                }
            }
        }
        public void deleteSON()//bağlı liste ile sondan silme
        {
            Bilgi gecici = ilk; Bilgi bironceki = ilk;
            while (gecici != son)//sondaki elamana ulaştırır.
            {            
                bironceki = gecici;
                gecici = gecici.sonraki;
            }
            if (gecici == son) 
            {
                son = bironceki;
                bironceki.sonraki = null;
            }

        }
        public void deleteTUM()
        {
            ilk = null;
            son = null;
        }//listeyi kırar
        public void deteteGIRILEN(int veri)//girilen no ile listenin ilgili kısımından o kişiyi siler
        {
            Bilgi gecici = ilk; Bilgi bironceki = ilk;
            while (gecici != null)//bir önceki ve aranan bağ bulunur.
            {
                if (veri == gecici.numara)
                {
                    break;
                }
                bironceki = gecici;
                gecici = gecici.sonraki;
            }
            if (gecici == null)
            {
                //burada bişeybelirle!!!!!!!!!!!!
            }
            {
                if (son == ilk)
                {
                    ilk = null;
                    son = null;
                }
                else
                {
                    if (gecici == ilk)
                    {
                        ilk = gecici.sonraki;
                    }
                    else
                    {
                        if (gecici == son)
                        {
                            son = bironceki;
                            bironceki.sonraki = null;
                        }
                        else//arara bir değer var ise 
                        {
                            bironceki.sonraki = gecici.sonraki;
                        }
                    }
                }
            }
        }
        public void list(ListBox o)// bağlı listeyi listeler
        {                 
            Bilgi gecici = ilk;
            while (gecici != null)
            {
                string baski = gecici.numara.ToString() + "-" + gecici.ad + "-" + gecici.ort.ToString() + "-" + gecici.ders;
                o.Items.Add(baski);
                gecici = gecici.sonraki;
            }
           
        }
        public void listNO(ListBox o)
        {           
            Bilgi[] dizi = new Bilgi[capacity()];//bağlı listeyi sıralama için diziye atıyoruz.
            Bilgi gecici = ilk;
            int a = 0;
            while (gecici != null)
            {
                dizi[a] = gecici;
                gecici = gecici.sonraki;
                a++;
            }

            for (int i = 0; i < dizi.Length-1; i++)//diziyi sıralıyoruz.
            {
                for (int k = 0; k < dizi.Length-1; k++)
                {
                    if (dizi[k].numara>= dizi[k+1].numara)
                    {
                        gecici = dizi[k + 1];
                        dizi[k + 1] = dizi[k];
                        dizi[k] = gecici;
                    }
                }
            }
            for (int i = 0; i < dizi.Length; i++)//ekrana basmak için kullanılmmıştır.
            {
                string baski = dizi[i].numara.ToString() + "-" + dizi[i].ad + "-" + dizi[i].ort.ToString() + "-" + dizi[i].ders;
                o.Items.Add(baski);
            }
        }//listeyi numara sırasına göre sıralar ve ekrana basar.
        public void listISIM(ListBox o)
        {            
            Bilgi[] dizi = new Bilgi[capacity()];
            Bilgi gecici = ilk;
            int a = 0;
            while (gecici != null)
            {
                dizi[a] = gecici;
                gecici = gecici.sonraki;
                a++;
            }

            for (int i = 0; i < dizi.Length - 1; i++)//  sıralama
            {
                for (int k = 0; k < dizi.Length - 1; k++)
                {
                    if (dizi[k].ad.CompareTo(dizi[k + 1].ad)>0)
                    {
                        gecici = dizi[k + 1];
                        dizi[k + 1] = dizi[k];
                        dizi[k] = gecici;
                    }
                }
            }
            for (int i = 0; i < dizi.Length; i++)
            {
                string baski = dizi[i].numara.ToString() + "-" + dizi[i].ad + "-" + dizi[i].ort.ToString() + "-" + dizi[i].ders;
                o.Items.Add(baski);
            }
        }//listeyi alfabetik olarak sıralar ve ekrana basar.
        public void listORT(ListBox o)
        {            
            Bilgi[] dizi = new Bilgi[capacity()];
            Bilgi gecici = ilk;
            int a = 0;
            while (gecici != null)
            {
                dizi[a] = gecici;
                gecici = gecici.sonraki;
                a++;
            }

            for (int i = 0; i < dizi.Length - 1; i++)//  sıralama
            {
                for (int k = 0; k < dizi.Length - 1; k++)
                {
                    if (dizi[k].ort >= dizi[k + 1].ort)
                    {
                        gecici = dizi[k + 1];
                        dizi[k + 1] = dizi[k];
                        dizi[k] = gecici;
                    }
                }
            }
            for (int i = 0; i < dizi.Length; i++)
            {
                string baski = dizi[i].numara.ToString() + "-" + dizi[i].ad + "-" + dizi[i].ort.ToString() + "-" + dizi[i].ders;
                o.Items.Add(baski);
            }
        }//Ortalamaya göre sıralar ve ekrana basar.
        public int capacity()
        {
            Bilgi gecici = ilk;
            int i = 0;
            while (gecici != null)
            {
                i++;
                gecici = gecici.sonraki;
            }
            return i;
        }
    }

}
