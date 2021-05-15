﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IUT_Vache
{


    public class Piquet
    {

        private static readonly List<Piquet> liste_piquet = new List<Piquet>();

        private readonly double x;
        private readonly double y;


        public Piquet(double x, double y)
        {
            this.x = x;
            this.y = y;
            liste_piquet.Add(this);
        }
        public static List<Piquet> GetList()
        {
            return liste_piquet;
        }
        public static int GetListCount()
        {
            return liste_piquet.Count;
        }
        public static double GetAire()
        {
            double aire = 0.0;

            //Calcul de la somme A en fonction du nombre de piquets

            for(int i = 0; i < (liste_piquet.Count)-1; i++)
            {
                Piquet piquet = liste_piquet[i];
                double coordX = piquet.x;
                double coordY = piquet.y;
                double coordXPlusUn = liste_piquet[i+1].x;
                double coordYPlusUn = liste_piquet[i+1].y;


                double segment = 
                    (coordX * coordYPlusUn) - (coordXPlusUn * coordY);

                //Si on arrive au dernier segment
                if (i == liste_piquet.Count - 2)
                {
                    double segmentNmoins1 = 
                        (liste_piquet[i+1].x * liste_piquet[0].y) - (liste_piquet[0].x * liste_piquet[i+1].y);

                    //Console.WriteLine("SEG0 = " + segmentNmoins1);
                    aire += segment + segmentNmoins1;
                }
                else
                {
                    aire += segment;
                }



            //Console.WriteLine("x" + i + " = " + aire + "-- Calcul effectué= " + coordX + " * " + coordYPlusUn + " - " + coordXPlusUn + " * " + coordY);
            }

            return aire*0.5;
        }
    }
}