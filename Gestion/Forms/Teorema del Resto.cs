using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Gestion.Forms {

    public partial class Teorema_del_Resto : EnClasesForm {
        public Teorema_del_Resto() {
            InitializeComponent();
        }

        //Creamos una clase nueva para almacenar terminos correctamente parseados
        private class Termino {
            //Esta clase puede guardar el coeficiente, exponente de un termino,
            // e indicar en caso de que el mismo sea un termino independiente(sin x)
            public int Coeficiente { get; set; }
            public int Exponente { get; set; }
            bool IsTerminoIndependiente { get; set; }


            // si solo se le pasa coeficiente, es temrino independiente
            public Termino(int _coeficiente) {
                Coeficiente = _coeficiente;
                IsTerminoIndependiente = true;
            }
            // si se le pasa coeficiente y exponente, es un termino comun
            public Termino(int _Coeficiente, int _exponente) {
                Coeficiente = _Coeficiente;
                Exponente = _exponente;
            }

        }

        //instancio una nueva lista generica de tipo 'Termino'
        List<Termino> Terminos = new List<Termino>();

        private void Teorema_del_Resto_Load(object sender, EventArgs e) {

        }

        //Este evento se ejecuta cada vez q se apreta una tecla dentro del maskedtextbox
        private void mTextBox_Edit1_KeyDown(object sender, KeyEventArgs e) {
            //si la tecla es diferente a enter, tira return, abortando la operacion
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Return) 
                return;
            //si no es diferente, sigue el camino, llamando al metodo ParseEc()
            ParseEc(mTextBox_Edit1.Text.Trim().ToUpper());


            //Finalmente, teniendo la lista completa, usamos consulta de linq, para ordenar los terminos
            // por exponente de mayor a menor.
            Terminos = (from a in Terminos
                       orderby a.Exponente descending
                       select a).ToList();


            int PonganElPuntoDeInterrupcionAcaParaVer = 1;

        }

        //        5x^3-4x^6+1x^5+2x^1-20
        //+:    5x^3 , 1x^5 , 2x^1
        //-:    -4x^6, -20

        private void ParseEc(string ecuacion) {
            //separa la ecuacion en terminos que empiecen con + o con -
            List<string> positivos = ecuacion.Split('+').ToList();
            List<string> negativos = ecuacion.Split('-').ToList();
            
            /*Correcciones Necesarias sobre la lista Negativos:
                1 - Si la ecuacion empeza con un termino negativo, y por ende tiene el '-' adelante
                    el split de arriba, va a generar un termino vacio en el primer slot de la lista.
                2 - En Cambio.. si la ecuacion empieza en positivo, y sin signo '+' explicito,
                    el mismo split, va a dejar en el primer slot, un termino positivo q no deberia estar.
                    En ambos casos, hay q borrar el primer elemento de la lista, asi que .. borramos sin 
                    checkear lo que hay.
             */
            negativos.Remove(negativos[0]);
            /*Correcciones Necesarias sobre la lista Positivos:
                1 - Si la ecuacion empieza con termino positivo, pero con el '+' explicito
                    el split va a generar un termino vacio, igual q en el caso 1 pero con los negativos.
                    esta correccion si, solo lo hacemos en el caso en q se encuentre el '+'. 
                2 - SI empieza con termino negativo, el split va a dejar el primer termino con un negativo, 
                    hay q sacarlo
             */

            if (ecuacion.StartsWith("+") || ecuacion.StartsWith("-"))
                positivos.Remove(positivos[0]);

            //desechamos los pedasos que no deberian quedar en cada elemento de la lista.
            //(Si no entienden porque esto es necesario.. miren con el debugger, y se van a dar cuenta)
            for (int i = 0; i < negativos.Count; i++) {
                negativos[i] = negativos[i].Split('+').First();
            }
            for (int i = 0; i < positivos.Count; i++) {
                positivos[i] = positivos[i].Split('-').First();
            }
            //Hacemos 2 listas de objetos clase 'Termino', para los negativos y positivos
            //(usando el metodo 'ParseListOfTerminos', y a agregamos a la Lista declarada al principio.
            Terminos.AddRange(ParseListOfTerminos(positivos, true));
            Terminos.AddRange(ParseListOfTerminos(negativos, false));
        }

        //Parsea listas de string como lista de objetos de clase 'Termino', con el parametro 
        //'TerminosPositivos', indicamos si la lista que estamos parseando, contiene terminos
        //positivos o negativos.
        private List<Termino> ParseListOfTerminos(List<string> lista, bool TerminosPositivos) {
            // Creamos una lista de terminos.
            List<Termino> Terms = new List<Termino>();
            // cicleamos entre cada elemento de la lista
            foreach (string termino in lista) {
                //declaramos variables para luego almacenar los coeficientes, y exponentes.
                int coeficiente;
                
                int? exponente = null; // int? = int que puede ser seteado en nulo
                
                //Nos fijamos si el termino contiene una incognita
                if (termino.Contains("X^")) {
                    // si el termino empieza con X, entonces es xq esta multiplicado por 1 (o por -1)
                    // entonces agregamos como coeficiente = 1
                    if (termino.StartsWith("X"))
                        coeficiente = 1;
                    else
                        // y si no, agregamos lo que esta antes de la x como coeficiente.
                        coeficiente = Convert.ToInt32(termino.Split('X').First());

                    //Y lo que esta despues del simbolo de potencia, como exponente.
                    //(si el string termina con X, entonces se entiende q es x^1)
                    if (termino.EndsWith("X"))
                        exponente = 1;
                    else
                        exponente = Convert.ToInt32(termino.Split('^').Last());
                }
                // en caso que no se encuentre una incognita, entonces tenemos el termino independiente
                else {
                    //asignamos solo el coeficiente
                    coeficiente = Convert.ToInt32(termino);


                }
                //Si la lista no es de terminos positivos, multiplicamos el coeficiente
                //por -1, para q sea negativo.
                if (!TerminosPositivos)
                    coeficiente = coeficiente * (-1);

                /*
                 Finalmente, checkeamos si 'exponente' no es nulo, y si no lo es
                 creamos un objeto de tipo 'Termino', y le pasamos el coeficiente y exponente,
                 (como el int del exponente es nulleable, tenemos que castearlo como int normal),
                 Si es nulo, al crearlo, solo le pasamos el coeficiente, asi la clase llama 
                 a otro constructor, y setea todo bien (revisar la declaracion de la clase)
                 */
            if (exponente != null) {
                    Termino _terminonuevo = new Termino(coeficiente, (int)exponente);
                    Terms.Add(_terminonuevo);
                }
                else {
                    Terms.Add(new Termino(coeficiente));
                    //Si!, podemos crear el objeto adentro del parentensis, 
                    //asi lo mandamos directo, sin declararlo primero.
                }
            }
            return Terms;
        }


    }
}


