using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion.Classes {
     static class ArraySorting {//Diferentes Metodos para Ordenar Arrays (aplicados a numeros)

        //Metodo de Burbuja: https://en.wikipedia.org/wiki/Bubble_sort.

        public static int[] Bubble(int[] array) {
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
            return array;
        }

        //Metodo de Quick Sort: https://en.wikipedia.org/wiki/Quicksort.

        public static int[] QuickSort(int[] a) {
            int[] arr = QuickSort(a, 0, a.Length - 1);
            return arr;
        }

        public static int[] QuickSort(int[] elements, int left, int right) {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];
            while (i <= j) {
                while (elements[i].CompareTo(pivot) < 0)
                    i++;
                while (elements[j].CompareTo(pivot) > 0)
                    j--;
                if (i <= j) {
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSort(elements, left, j);
            if (i < right)
                QuickSort(elements, i, right);
            return elements;
        }

        //Metodo HeapSort: https://en.wikipedia.org/wiki/Heapsort.

        public static int[] HeapSort(int[] input) {
            //Build-Max-Heap
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (int i = input.Length - 1; i > 0; i--) {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
            return input;
        }

        private static void MaxHeapify(int[] input, int heapSize, int index) {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index) {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }

        //Metodo Insertion Sort: https://en.wikipedia.org/wiki/Insertion_sort.

        public static int[] InsertionSort(int[] inputarray) {
            for (int i = 0; i < inputarray.Length - 1; i++) {
                int j = i + 1;

                while (j > 0) {
                    if (inputarray[j - 1] > inputarray[j]) {
                        int temp = inputarray[j - 1];
                        inputarray[j - 1] = inputarray[j];
                        inputarray[j] = temp;

                    }
                    j--;
                }
            }
            return inputarray;
        }
    }
}