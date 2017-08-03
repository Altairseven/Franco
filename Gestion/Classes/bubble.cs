using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion.Classes {
    class bubble {

        public int[] resultado;

        public bubble(int[] array) {
            int aux;
            for (int i = 0; i < array.Length - 1; i++) {
                for (int j = i + 1; j < array.Length; j++) {
                    if (array[i] > array[j]) {
                        aux = array[i];
                        array[i] = array[j];
                        array[j] = aux;
                    }
                }
            }
            resultado = array;
        }

        //Leer esto... es una mejor solucion, despues lo implemento.
        //https://stackoverflow.com/questions/9540905/multiple-constructors-with-one-parameter



        //public bubble(System.Windows.Forms.ListBox listbox) {
        //    int[] array = new int[listbox.Items.Count];
        //    for (int i = 0; i < listbox.Items.Count -1; i++) {
        //        array[i] = (int)listbox.Items[i];
        //    }



        //    resultado = tointarray;
        //}
    }
}

