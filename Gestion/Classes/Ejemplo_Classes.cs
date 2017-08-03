//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace Gestion.Classes {

//    //Ejemplo de una clase como las veniamos trabajando el año pasado:
//    public class Clase1 {
                
//        int teta;
//        public int culo;

//        public void Metodo1() {
//            int culoalcuadrado = Metodo2(culo);
//            Metodo3(culoalcuadrado.ToString());
//        }
//        int Metodo2(int numero) {
//            return numero * numero;
//        }
        
//        void Metodo3(string valorculo) {
//            //Messagebox.Show(valorculo);
//        }

//    }
//    class Ejemplo_conClase1 {
//        Clase1 asd = new Clase1();
       







//    }
//    //Esta Clase es mas compleja mete constructors y overloads.
//    class Clase2 {

//        int numero1 = 10;
//        int numero2 = 5;
//        public int resultado;

//        public Clase2() {
//            resultado = numero1 + numero2;
//        }
//        public Clase2(int numero3) {
//            resultado = numero1 + numero3;
//        }
//        public Clase2(int numero3, int numero4) {
//            resultado = numero3 + numero4;
//        }
//    }
//    class Ejemplo_conClase2 {
//        Clase2 pepe = new Clase2();
        





//    }











//    //Clase Orientada a objetos.
//    //la idea es que representa a un objeto de la realidad.
//    class Vehiculo {

//        private int cantidad_ruedas;
//        private decimal velocidad_Maxima;
//        private decimal velocidad_actual;

//        public Vehiculo() {
//            velocidad_Maxima = 135.5M;
//        }


//        public void Moverse() {
//            //accion de mover el vehiculo
//            velocidad_actual = velocidad_Maxima;
//        }
//        public virtual void Frenar() {
//            //accion de dejar de mover el vehiculo
//            velocidad_actual = 0;
//        }
        

//    }

//    class Bicicleta : Vehiculo {


//    }

//    class Auto : Vehiculo {

//        bool lucesFrenoOn = false;

//        public Auto() {

//        }

//        void Aire_Acondicionado() {

//        }
//        public override void Frenar() {
//            base.Frenar();
//            lucesFrenoOn = true;
            
//        }

//    }

//    class Ejemplo_conClaseVehiculo {

        




//    }


}
