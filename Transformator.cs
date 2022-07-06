using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerLoadLosses
{
    class Transformator
    {

        private double U;

        public double Unom
        {
            get { return U; }
            set
            {
                if (value < 0) U = 0;
                else U = value;
            }
        }
        private double S;

        public double Snom
        {
            get { return S; }
            set
            {
                if (value < 0) S = 0;
                else S = value;
            }
        }

        public double Pxx { get; set; }
        public double Pкз { get; set; }


        public Transformator(int U, int S, int Pxx, int Pкз)
        {
            Unom = U;
            Snom = S;
            this.Pxx = Pxx;
            this.Pкз = Pкз;

        }

        //перегруженный метод создает массив точек для построения графика нагрузочных потерь трансформатора

        //возвращает массив значений для переменной мощности осьХ
        public static double[] LoadLossesTrans(int step, double length)
        {

            double[] VariablePower = new double[(int)(length / step) + 1];

            for (int i = 0; i < VariablePower.Length; i++)
            {
                VariablePower[i] = i * step;
            }

            return VariablePower;
        }

        //массив значений нагрузочных потерь одного трансформатора осьY
        public static double[] LoadLossesTrans(int step, Transformator PRIME)
        {

            double[] ArrOneTrans = new double[(int)(PRIME.Snom * 2 / step) + 1];


            for (int i = 0; i < ArrOneTrans.Length; i ++)
            {
                //формула для графика нагрузочных потерь одного трансформатора

                ArrOneTrans[i] = Math.Pow(i*step / PRIME.Snom, 2) * PRIME.Pкз + PRIME.Pxx;

            }

            return ArrOneTrans;
        }

        //массив значений нагрузочных потерь двух параллельных трансформаторов осьY 
        public static double[] LoadLossesTrans(int step, Transformator PRIME, Transformator SECOND)
        {

            double[] ArrTwoTrans = new double[(int)(PRIME.Snom * 2 / step) +1];

            for (int i = 0; i < ArrTwoTrans.Length; i ++)
            {
                ArrTwoTrans[i] = Math.Pow(i*step / PRIME.Snom, 2) * (PRIME.Pкз * SECOND.Pкз / (PRIME.Pкз + SECOND.Pкз)) + (PRIME.Pxx + SECOND.Pxx);

            }

            return ArrTwoTrans;
        }


    }
}
