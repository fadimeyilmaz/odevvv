﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Market_otomasyon.Moduls.Entity;
using Market_otomasyon.Context;
using System.Data.SqlClient;

namespace Market_otomasyon
{
    public partial class ÜrünStok : Form
    {

        public ÜrünStok()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            TedarikçiBilgi tedarikci = new TedarikçiBilgi();
            tedarikci.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Ana_menu ANA = new Ana_menu();
            ANA.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            müşteriler müşteri = new müşteriler();
            müşteri.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Giris_ekrani giris = new Giris_ekrani();
            giris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      
        

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader oku = new StreamReader(openFileDialog1.FileName);
                string satir = oku.ReadLine();


                while (satir != null)
                {
                    string[] itemler = satir.Split(' ');
                    listBox1.Items.Add(satir);
                    satir = oku.ReadLine();

                    Stok ürünn = new Stok();
                    MarketDbContext context = new MarketDbContext();

                    int count = 1;

                    if (count == 1)
                    {
                        ürünn.UrunKodu = Convert.ToInt32(itemler[1]);
                    }

                    if (count == 2)
                    {
                        ürünn.Barkod = Convert.ToInt32(itemler[2]);
                    }

                    if (count == 3)
                    {
                        ürünn.Cesit = itemler[3];
                    }

                    if (count == 4)
                    {
                        ürünn.StokMiktari = Convert.ToInt32(itemler[4]);
                    }

                    if (count == 5)
                    {
                        ürünn.UrunAdi = itemler[5];
                    }

                    if (count == 6)
                    {
                        ürünn.BirimGirdiFiyat = Convert.ToInt32(itemler[6]);
                        context.Stoks.Add(ürünn);
                        context.SaveChanges();
                    }


                    count = count + 1;

                }
                }

            }
        }
}

