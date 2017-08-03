using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion.Classes;

namespace Gestion.Forms {
    public partial class Algoritmos_Ordenamiento_Arrays : OwnForm {
        public Algoritmos_Ordenamiento_Arrays() {
            InitializeComponent();
        }

        int currenttab;
        string[] refadd = new string[4] {
            "https://en.wikipedia.org/wiki/Bubble_sort",
            "https://en.wikipedia.org/wiki/Quicksort",
            "https://en.wikipedia.org/wiki/Heapsort",
            "https://en.wikipedia.org/wiki/Insertion_sort"
        };
        //Classes.ArraySorting ArrS = new Classes.ArraySorting(); 


        private void Algoritmos_Ordenamiento_Arrays_Load(object sender, EventArgs e) {
            On_tab_change();
            listapotente l = new listapotente(1,"a",2f);
            
            
        }

        private void Random_gen(ListBox list, int count, int from, int to) {
            list.Items.Clear();
            Random r = new Random();
            for (int i = 0; i < count; i++) {
                listBox1.Items.Add(r.Next(from, to));
            }
        }
        private void On_tab_change() {
            Random_gen(listBox1, 20, 1, 100);
            listBox2.Items.Clear();
            currenttab = tabControl1.SelectedIndex;
            switch (currenttab) {
                case 0: label1.Text = refadd[0]; this.Text = "Ordenando Con Burbuja"; button1.Text= "Ordenar Con Burbuja"; break;
                case 1: label1.Text = refadd[1]; this.Text = "Ordenando Con Quick Sort"; button1.Text = "Ordenar Con Quick Sort"; break;
                case 2: label1.Text = refadd[2]; this.Text = "Ordenando Con Heap Sort"; button1.Text = "Ordenar Con Heap Sort"; break;
                case 3: label1.Text = refadd[3]; this.Text = "Ordenando Con Insertion Sort"; button1.Text = "Ordenar Con Insertion Sort"; break;
            }

        }
        private void TabControl1_Selected(object sender, TabControlEventArgs e) {
            On_tab_change();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (listBox1.Items.Count != 0) {
                listBox2.Items.Clear();
                int[] arr = new int[listBox1.Items.Count];
                for (int i = 0; i < arr.Length; i++) {
                    arr[i] = (int)listBox1.Items[i];
                }

                
                switch (currenttab) {
                    case 0: arr = ArraySorting.Bubble(arr); break;
                    case 1: arr = ArraySorting.QuickSort(arr); break;
                    case 2: arr = ArraySorting.HeapSort(arr); break;
                    case 3: arr = ArraySorting.InsertionSort(arr); break;
                }
                    foreach (int a in arr)
                        listBox2.Items.Add(a.ToString());

            }

        }

        private void label1_Click(object sender, EventArgs e) {
            string addrToShow = "localhost";
            switch (currenttab) {
                case 0: addrToShow = refadd[0]; break;
                case 1: addrToShow = refadd[1]; break;
                case 2: addrToShow = refadd[2]; break;
                case 3: addrToShow = refadd[2]; break;
            }

            System.Diagnostics.Process.Start(addrToShow);
        }
    }
}
