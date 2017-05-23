using System;
using System.Collections.Generic;

namespace KMeansClustering
{
    static class GlobalClass
    {
        private static string distType = "";
        public static string DistType
        {
            get { return distType; }
            set { distType = value; }
        }
    }

    class KMeansProgram
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\nBegin K-Means Clustering\n");

            //data for euclidean distance example
            /*double[][] rawData = new double[4][];
            rawData[0] = new double[] { 1, 1 };
            rawData[1] = new double[] { 2, 1 };
            rawData[2] = new double[] { 4, 3 };
            rawData[3] = new double[] { 5, 4 };*/


            //data for manhattan distance example
            /*double[][] rawData = new double[8][];
            rawData[0] = new double[] { 2, 10 }; //A1
            rawData[1] = new double[] { 2, 5 };  //A2
            rawData[2] = new double[] { 8, 4 };  //A3
            rawData[3] = new double[] { 5, 8 };  //A4
            rawData[4] = new double[] { 7, 5 };  //A5
            rawData[5] = new double[] { 6, 4 };  //A6
            rawData[6] = new double[] { 1, 2 };  //A7
            rawData[7] = new double[] { 4, 9 };  //A8
            */

            // data for microsoft example
              double[][] rawData = new double[20][];
              rawData[0] = new double[] { 65.0, 220.0 };
              rawData[1] = new double[] { 73.0, 160.0 };
              rawData[2] = new double[] { 59.0, 110.0 };
              rawData[3] = new double[] { 61.0, 120.0 };
              rawData[4] = new double[] { 75.0, 150.0 };
              rawData[5] = new double[] { 67.0, 240.0 };
              rawData[6] = new double[] { 68.0, 230.0 };
              rawData[7] = new double[] { 70.0, 220.0 };
              rawData[8] = new double[] { 62.0, 130.0 };
              rawData[9] = new double[] { 66.0, 210.0 };
              rawData[10] = new double[] { 77.0, 190.0 };
              rawData[11] = new double[] { 75.0, 180.0 };
              rawData[12] = new double[] { 74.0, 170.0 };
              rawData[13] = new double[] { 70.0, 210.0 };
              rawData[14] = new double[] { 61.0, 110.0 };
              rawData[15] = new double[] { 58.0, 100.0 };
              rawData[16] = new double[] { 66.0, 230.0 };
              rawData[17] = new double[] { 59.0, 120.0 };
              rawData[18] = new double[] { 68.0, 210.0 };
              rawData[19] = new double[] { 61.0, 130.0 };

            //data for grades example

            /*  double[][] rawData = new double[38][];
              rawData[0] = new double[] { 1, 83.70 };
              rawData[1] = new double[] { 1, 82.04 };
              rawData[2] = new double[] { 1, 81.49 };
              rawData[3] = new double[] { 1, 86.95 };
              rawData[4] = new double[] { 1, 79.09 };
              rawData[5] = new double[] { 1, 85.12 };
              rawData[6] = new double[] { 1, 85.61 };
              rawData[7] = new double[] { 1, 86.30 };
              rawData[8] = new double[] { 1, 79.89 };
              rawData[9] = new double[] { 1, 47.55 };
              rawData[10] = new double[] { 1, 88.67 };
              rawData[11] = new double[] { 1, 74.57 };
              rawData[12] = new double[] { 1, 90.90 };
              rawData[13] = new double[] { 1, 92.63 };
              rawData[14] = new double[] { 1, 74.33 };
              rawData[15] = new double[] { 1, 80.58 };
              rawData[16] = new double[] { 1, 75.20 };
              rawData[17] = new double[] { 1, 79.24 };
              rawData[18] = new double[] { 1, 79.68 };
              rawData[19] = new double[] { 1, 86.88 };
              rawData[20] = new double[] { 1, 73.43 };
              rawData[21] = new double[] { 1, 84.63 };
              rawData[22] = new double[] { 1, 85.82 };
              rawData[23] = new double[] { 1, 77.60 };
              rawData[24] = new double[] { 1, 63.84 };
              rawData[25] = new double[] { 1, 75.80 };
              rawData[26] = new double[] { 1, 71.18 };
              rawData[27] = new double[] { 1, 82.03 };
              rawData[28] = new double[] { 1, 66.13 };
              rawData[29] = new double[] { 1, 83.32 };
              rawData[30] = new double[] { 1, 76.75 };            
              rawData[31] = new double[] { 1, 70.38 };
              rawData[32] = new double[] { 1, 79.03 };
              rawData[33] = new double[] { 1, 47.89 };
              rawData[34] = new double[] { 1, 86.99 };
              rawData[35] = new double[] { 1, 93.85 };
              rawData[36] = new double[] { 1, 88.83 };
              rawData[37] = new double[] { 1, 84.01 };*/

            /*
            double[][] rawData = new double[7][];

            rawData[0] = new double[] { 1.1, 60 };
            rawData[1] = new double[] { 8.2, 20 };
            rawData[2] = new double[] { 4.2, 35 };
            rawData[3] = new double[] { 1.5, 21 };
            rawData[4] = new double[] { 7.6, 15 };
            rawData[5] = new double[] { 2.0, 55 };
            rawData[6] = new double[] { 3.9, 33 };
            */

            Console.WriteLine("Raw unclustered data:\n");
            //Console.WriteLine("    Height Weight");
            //Console.WriteLine(" Grades");
            Console.WriteLine(" Coordinates");
            Console.WriteLine("-------------------");
            ShowData(rawData, 1, true, true);

            Console.WriteLine("Enter number of clusters");
            int numClusters = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Setting numClusters to " + numClusters);

            Console.WriteLine("\nEuclidean <E> or Manhattan <M>?");
            GlobalClass.DistType = Console.ReadLine();

            Console.WriteLine("\nStarting clustering");
            int[] clustering = Cluster(rawData, numClusters, 0);

            Console.WriteLine("Clustering complete\n");

            Console.WriteLine("Final clustering in internal format:\n");
            ShowVector(clustering, true);

            Console.WriteLine("Raw data by cluster:\n");
            ShowClustered(rawData, clustering, numClusters, 1);
            Console.ReadLine();
        } // Main

        public static int[] Cluster(double[][] rawData, int numClusters, int seed)
        {
            // k-means++ clustering
            // index of return is tuple ID, cell is cluster ID
            // ex: [2 1 0 0 2 2] means tuple 0 is in cluster 2, tuple 1 in cluster 1,
            //  tuple 2 in cluster 0, tuple 3 in cluster 0, etc.
            double[][] data = Normalized(rawData); // so large values don't dominate

            bool changed = true; // change in at least one cluster assignment?
            bool success = true; // all means computed? (no zero-count clusters)

            double[][] means = InitMeans(numClusters, data, seed); // k-means++ 

            int[] clustering = new int[data.Length]; // all 0

            int maxCount = data.Length * 10; // sanity check
            int ct = 0;
            while (changed == true && success == true && ct < maxCount) // technically this is Lloyd's algorithm
            {
                changed = UpdateClustering(data, clustering, means); // (re)assign tuples to clusters. no effect if fail
                success = UpdateMeans(data, clustering, means); // compute new cluster means if possible. no effect if fail
                ++ct; // k-means typically converges very quickly
            }
            // could check for 0-count clusters here
            return clustering;
        }

        private static double[][] InitMeans(int numClusters, double[][] data, int seed)
        {
            // select k data items as initial means using k-means++ mechanism:
            // pick one data item at random as first mean
            // loop k-1 times (remaining means)
            //   compute dist^2 from each item to closest mean
            //   pick a data item w/ large dist^2 as next mean
            // end loop

            double[][] means = MakeMatrix(numClusters, data[0].Length); // result

            List<int> used = new List<int>(); // track which items already means

            // select one data item index at random
            Random rnd = new Random(seed);
            int idx = rnd.Next(0, data.Length); // [0, data.Length-1]
            Array.Copy(data[idx], means[0], data[idx].Length);
            used.Add(idx); // we don't want to select this item again

            for (int k = 1; k < numClusters; ++k) // each remaining mean
            {
                double[] dSquared = new double[data.Length]; // to closest mean
                int newMean = -1; // index of data item to be a new mean
                for (int i = 0; i < data.Length; ++i) // for each data item
                {
                    // if data item i is already a mean, skip the item
                    if (used.Contains(i) == true) continue; // not entirely necessary

                    // compute distances from data[i] to each existing mean (to find closest)
                    double[] distances = new double[k]; // we currently have k means
                    for (int j = 0; j < k; ++j)
                        distances[j] = Distance(data[i], means[k]); // could do dist^2 directly   

                    // now get the index of the closest mean
                    int m = MinIndex(distances);
                    // save the associated distance-squared
                    dSquared[i] = distances[m] * distances[m];
                }

                // pick one of the data items, using the squared distances
                // this is a form of roulette wheel selection
                double p = rnd.NextDouble();
                double sum = 0.0; // sum of distances-squared 
                for (int i = 0; i < dSquared.Length; ++i)
                    sum += dSquared[i];
                double cumulative = 0.0; // cumulatiive probability

                int ii = 0; // points into distancesSquared[]
                int sanity = 0; // sanity count
                while (sanity < data.Length * 2) // 'stochastic acceptance'
                {
                    cumulative += dSquared[ii] / sum;
                    if (cumulative >= p && used.Contains(ii) == false)
                    {
                        newMean = ii; // the chosen index
                        used.Add(newMean); // don't pick again
                        break;
                    }
                    ++ii; // next candidate
                    if (ii >= dSquared.Length) ii = 0; // back to first item
                    ++sanity;
                }
                // check if newMean is still -1 . . . 

                // save the data of the chosen index
                Array.Copy(data[newMean], means[k], data[newMean].Length);
            } // k, each mean/cluster

            return means;

        } // InitMeans

        private static double[][] Normalized(double[][] rawData)
        {
            // normalize raw data by computing (x - mean) / stddev
            // one alternative is min-max:
            // v' = (v - min) / (max - min)

            // make a copy of input data
            double[][] result = new double[rawData.Length][];
            for (int i = 0; i < rawData.Length; ++i)
            {
                result[i] = new double[rawData[i].Length];
                Array.Copy(rawData[i], result[i], rawData[i].Length);
            }

            for (int j = 0; j < result[0].Length; ++j) // each col
            {
                double colSum = 0.0;
                for (int i = 0; i < result.Length; ++i)
                    colSum += result[i][j];
                double mean = colSum / result.Length;
                double sum = 0.0;
                for (int i = 0; i < result.Length; ++i)
                    sum += (result[i][j] - mean) * (result[i][j] - mean);
                double sd = sum / result.Length;
                if (sd == 0)
                    sd = 1;
                for (int i = 0; i < result.Length; ++i)
                    result[i][j] = (result[i][j] - mean) / sd;
            }
            return result;
        }

        private static double[][] MakeMatrix(int rows, int cols)
        {
            // convenience matrix allocator for Cluster()
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        private static bool UpdateMeans(double[][] data, int[] clustering, double[][] means)
        {
            // returns false if there is a cluster that has no tuples assigned to it
            // parameter means[][] is really a ref parameter

            // check existing cluster counts
            // can omit this check if InitClustering and UpdateClustering
            // both guarantee at least one tuple in each cluster (usually true)
            int numClusters = means.Length;
            int[] clusterCounts = new int[numClusters];
            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = clustering[i];
                ++clusterCounts[cluster];
            }

            for (int k = 0; k < numClusters; ++k)
                if (clusterCounts[k] == 0)
                    return false; // bad clustering. no change to means[][]

            // update, zero-out means so it can be used as scratch matrix 
            for (int k = 0; k < means.Length; ++k)
                for (int j = 0; j < means[k].Length; ++j)
                    means[k][j] = 0.0;

            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = clustering[i];
                for (int j = 0; j < data[i].Length; ++j)
                    means[cluster][j] += data[i][j]; // accumulate sum
            }

            for (int k = 0; k < means.Length; ++k)
                for (int j = 0; j < means[k].Length; ++j)
                    means[k][j] /= clusterCounts[k]; // danger of div by 0
            return true;
        }

        private static bool UpdateClustering(double[][] data, int[] clustering,
          double[][] means)
        {
            // (re)assign each tuple to a cluster (index of closest mean)
            // returns false if no tuple assignments change OR
            // if the reassignment would result in a clustering where
            // one or more clusters have no tuples.

            int numClusters = means.Length;
            bool changed = false;

            int[] newClustering = new int[clustering.Length]; // proposed result
            Array.Copy(clustering, newClustering, clustering.Length);

            double[] distances = new double[numClusters]; // from curr tuple to each mean

            for (int i = 0; i < data.Length; ++i) // walk thru each tuple
            {
                for (int k = 0; k < numClusters; ++k)
                    distances[k] = Distance(data[i], means[k]); // usually Euclidean

                int newClusterID = MinIndex(distances); // find closest mean ID
                //Console.WriteLine("new cluster Id = " + newClusterID);
                //Console.ReadLine();
                if (newClusterID != newClustering[i])
                {
                    changed = true;
                    newClustering[i] = newClusterID; // update
                }
            }

            if (changed == false)
                return false; // no change so bail and don't update clustering[][]

            // check proposed clustering[] cluster counts
            int[] clusterCounts = new int[numClusters];
            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = newClustering[i];
                ++clusterCounts[cluster];
            }

            for (int k = 0; k < numClusters; ++k)
                if (clusterCounts[k] == 0)
                    return false; // bad clustering. no change to clustering[][]

            Array.Copy(newClustering, clustering, newClustering.Length); // update
            return true; // no empty clusters and at least one change
        }

        private static double Distance(double[] tuple, double[] mean)
        {
            // Euclidean distance between two vectors for UpdateClustering()
            if (string.Compare(GlobalClass.DistType, "E") == 0)
            {
                double sumSquaredDiffs = 0.0;
                for (int j = 0; j < tuple.Length; ++j)
                    sumSquaredDiffs += Math.Pow((tuple[j] - mean[j]), 2);
                return Math.Sqrt(sumSquaredDiffs);
            }

            //Manhattan distance
            else if (string.Compare(GlobalClass.DistType, "M") == 0)
            {
                double sumDiffs = 0.0;
                for (int j = 0; j < tuple.Length; ++j)
                    sumDiffs += Math.Abs((tuple[j] - mean[j]));
                return sumDiffs;
            }
            return 99999;
        }

        private static int MinIndex(double[] distances)
        {
            // index of smallest value in array
            // helper for UpdateClustering()
            int indexOfMin = 0;
            double smallDist = distances[0];
            for (int k = 0; k < distances.Length; ++k)
            {
                if (distances[k] < smallDist)
                {
                    smallDist = distances[k];
                    indexOfMin = k;
                }
            }
            return indexOfMin;
        }

        static void ShowData(double[][] data, int decimals,
          bool indices, bool newLine)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (indices) Console.Write(i.ToString().PadLeft(3) + " ");
                for (int j = 0; j < data[i].Length; ++j)        // j = 0 (2D array) / j = 1 (grades example)
                {
                    if (data[i][j] >= 0.0) Console.Write(" ");
                    Console.Write(data[i][j].ToString("F" + decimals) + " ");
                }
                Console.WriteLine("");
            }
            if (newLine) Console.WriteLine("");
        } // ShowData

        static void ShowVector(int[] vector, bool newLine)
        {
            for (int i = 0; i < vector.Length; ++i)
                Console.Write(vector[i] + " ");
            if (newLine) Console.WriteLine("\n");
        }

        static void ShowVector(double[] vector, int decimals, bool newLine)
        {
            for (int i = 0; i < vector.Length; ++i)
                Console.Write(vector[i].ToString("F" + decimals) + " ");
            if (newLine) Console.WriteLine("\n");
        }

        static void ShowClustered(double[][] data, int[] clustering,
          int numClusters, int decimals)
        {
            for (int k = 0; k < numClusters; ++k)
            {
                Console.WriteLine("===================");
                for (int i = 0; i < data.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k) continue;
                    Console.Write(i.ToString().PadLeft(3) + " ");
                    for (int j = 0; j < data[i].Length; ++j)        // j = 0 (2D array) / j = (grades example)
                    {
                        if (data[i][j] >= 0.0) Console.Write(" ");
                        Console.Write(data[i][j].ToString("F" + decimals) + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("===================");
            } // k
        } // ShowClustered

    } // Program class

} // ns
