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

        //перегруженный метод создает массив точек для построения графика нагрузочных потерь одного трансформатора,

        public static double[] LoadLossesTrans(Transformator PRIME)
        {
            int step = 800;
           
            double[] VariablePower = new double[(int)PRIME.Snom * 2 + 1];

            for (int i = 0; i <= PRIME.Snom * 2; i += step)
            {
                VariablePower[i] = i;
            }

            return VariablePower;
        }

        public static double[] LoadLossesOneTrans(Transformator PRIME)
        {
            int step = 800;
            double[] ArrOneTrans = new double[(int)PRIME.Snom * 2 + 1];


            for (int i = 0; i <= PRIME.Snom * 2; i += step)
            {
                //формула для графика нагрузочных потерь одного трансформатора
                ArrOneTrans[i] = Math.Pow(i / PRIME.Snom, 2) * PRIME.Pкз + PRIME.Pxx;

            }

            return ArrOneTrans;
        }

        //метод создает массив точек для построения графика нагрузочных потерь двух параллельных трансформатора
        public static double[] LoadLossesTrans(Transformator PRIME, Transformator SECOND)
        {
            int step = 800;
            double[] ArrTwoTrans = new double[(int)PRIME.Snom * 2 + 1];
            int[] VariablePower = new int[(int)PRIME.Snom * 2 + 1];

            for (int i = 0; i <= PRIME.Snom * 2; i += step)
            {
                ArrTwoTrans[i] = Math.Pow(i / PRIME.Snom, 2) * (PRIME.Pкз * SECOND.Pкз / (PRIME.Pкз + SECOND.Pкз)) + (PRIME.Pxx + SECOND.Pxx);
                VariablePower[i] = i;
            }

            return ArrTwoTrans;
        }


    }
}
