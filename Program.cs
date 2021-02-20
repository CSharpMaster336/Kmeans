using System;
using System.Collections.Generic;
namespace KMeans_2._1
{
    class Program
    {


        static void Main(string[] args)
        {
            int DataLen = 200;
            double DataMax = 1.1;
            int K = 5;
            int TrainingTime = 10;
            List<double> Data = new List<double>();
            List<List<double>> Clusters = new List<List<double>>();
            double[] Centroids = new double[K];
            Random random = new Random();

            #region Initial Assingnents
            for (int i = 0; i < K; i++)
            {
                Centroids[i] = random.NextDouble();
                Clusters.Add(new List<double>());
            }
            for (int i = 0; i < DataLen; i++)
            {
                Data.Add(random.NextDouble());
            }
            #endregion

            void Display()
            {
                for (int i = 0; i < K; i++)
                {
                    Console.WriteLine($"Cluster::{i}");
                    foreach (var item in Clusters[i])
                    {
                        Console.WriteLine(item);
                    }
                }

            }
            void Cluster()
            {
                double Smallest = 0;
                List<double> Distances = new List<double>();
                for (int i = 0; i < Data.Count; i++)
                {
                    double Point = Data[i];
                    int Index = 0;
                    
                    for (int j = 0; j < K; j++)
                    {
                        double Centroid = Centroids[j];
                        Distances.Add(Distance(Centroid, Point));
                        Index = j;
                    }

                    Clusters[MinIndex(Distances)].Add(Point);
                    Distances.Clear();
                }
            }
            //First Clustering
            Cluster();
            Display();
            Console.WriteLine("\n\n\n\n\n");
            foreach (var item in Data)
            {
                Console.WriteLine(item);
            }



        }
        static double Distance(double a, double b)
        {
            if (a > b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }
        static int MinIndex(List<double> Nums)
        {
            double Smallest = 2;
            int Index = 0;
            for (int i = 0; i < Nums.Count; i++)
            {
                if (Nums[i] < Smallest)
                {
                    Smallest = Nums[i];
                    Index = i;
                }
            }
            return Index;
        }
    }
}
