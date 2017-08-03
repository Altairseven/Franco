using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion.Forms {
    public partial class Suck_It_Java : OwnForm {
        public Suck_It_Java() {
            InitializeComponent();
        }
        private void AddToList(ListBox LB,string Texto) {
            if (Texto != "") {
                LB.Items.Add(Texto);
                textBox1.Clear();
                textBox1.Focus();
            }
        }
        private void RemoveSelectedFromList(ListBox LB) {
            for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--) {
                int idx = listBox1.SelectedIndices[x];
                listBox1.Items.RemoveAt(idx);
            }
        }
        private void MoveToList(ListBox Origen, ListBox Destino) {
            for (int x = Origen.SelectedIndices.Count - 1; x >= 0; x--) {
                int idx = Origen.SelectedIndices[x];
                AddToList(Destino, Origen.Items[idx].ToString());
                Origen.Items.RemoveAt(idx);
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            AddToList(listBox1,textBox1.Text);
        }
        private void button3_Click(object sender, EventArgs e) {
            AddToList(listBox2, textBox1.Text);
        }
        private void button4_Click(object sender, EventArgs e) {
            RemoveSelectedFromList(listBox1);
        }
        private void button5_Click(object sender, EventArgs e) {
            RemoveSelectedFromList(listBox2);
        }
        private void button1_Click(object sender, EventArgs e) {
            MoveToList(listBox1, listBox2);
        }
        private void button6_Click(object sender, EventArgs e) {
            MoveToList(listBox2, listBox1);
        }

        private void Suck_It_Java_Load(object sender, EventArgs e) {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox2.SelectionMode = SelectionMode.MultiExtended;
        }
    }
}
