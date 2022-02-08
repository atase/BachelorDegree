using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungarianAlgorithm
{
    public class HungarianAlgorithm
    {
        private const int DIM = 50; // max number of vertices in one part
        private const int INF = 1000000;

        private int[,] costMatrix = new int[DIM, DIM]; // cost matrix

        private int[] labelG = new int[DIM]; // labels for givers
        private int[] labelR = new int[DIM]; // labels for receivers

        private int noSubjects; // number of givers = number of receivers 
        private int maxMatching = 0; // length of matching

        private int[] gr = new int[DIM]; // receiver that is matched with giver
        private int[] rg = new int[DIM]; // giver that is matched with receiver

        private bool[] S = new bool[DIM]; // giver matched
        private bool[] T = new bool[DIM]; // receiver matched

        private int[] array = new int[DIM];
        private int[] arrayX = new int[DIM];

        private int[] path = new int[DIM]; // array for memorizing alternating paths


        private void InitializeLabels()
        {
            labelG = Enumerable.Repeat(0, DIM).ToArray();
            labelR = Enumerable.Repeat(0, DIM).ToArray();

            for (int i = 0; i < noSubjects; i++)
            {
                for (int j = 0; j < noSubjects; j++)
                {
                    labelG[i] = Math.Max(labelG[i], costMatrix[i, j]);
                }
            }
        }

        private void Augment()
        {
            if (maxMatching == noSubjects) return;

            S = Enumerable.Repeat(false, DIM).ToArray();
            T = Enumerable.Repeat(false, DIM).ToArray();
            path = Enumerable.Repeat(-1, DIM).ToArray();

            int root = 0, i = 0, j = 0;
            Queue<int> q = new Queue<int>();

            for (i = 0; i < noSubjects; i++)
            {
                if (gr[i] == -1)
                {
                    root = i;
                    q.Enqueue(i);
                    path[i] = -2;
                    S[i] = true;
                    break;
                }
            }


            for (j = 0; j < noSubjects; j++)
            {
                array[j] = labelG[root] + labelR[j] - costMatrix[root, j];
                arrayX[j] = root;
            }

            while (true)
            {
                while (q.Count() != 0)
                {
                    i = q.Dequeue();

                    for (j = 0; j < noSubjects; j++)
                    {
                        if ((costMatrix[i, j] == labelG[i] + labelR[j]) && !T[j])
                        {
                            if (rg[j] == -1)
                            {
                                break;
                            }

                            T[j] = true;
                            q.Enqueue(rg[j]);
                            AddEdge(rg[j], i);
                        }
                    }


                    if (j < noSubjects)
                    {
                        break;
                    }
                }

                if (j < noSubjects)
                {
                    break;
                }

                UpdateLabels();

                for (j = 0; j < noSubjects; j++)
                {
                    if (!T[j] && array[j] == 0)
                    {
                        if (rg[j] == -1)
                        {
                            i = arrayX[j];
                            break;
                        }
                        else 
                        {
                            T[j] = true;

                            if (!S[rg[j]])
                            {
                                q.Enqueue(rg[j]);
                                AddEdge(rg[j], arrayX[j]);
                            }
                        }
                    }
                }


                if (j < noSubjects)
                {
                    break;
                }
            }

            if (j < noSubjects)
            {
                maxMatching++;

                for (int cx = i, cy = j, ty = 0; cx != -2; cx = path[cx], cy = ty)
                {
                    ty = gr[cx];
                    rg[cy] = cx;
                    gr[cx] = cy;
                }

                Augment();
            }

        }


        private void UpdateLabels()
        {
            int delta = INF;
            for (int j = 0; j < noSubjects; j++)
            {
                if (!T[j])
                {
                    delta = Math.Min(delta, array[j]); // calculate delta;
                }
            }

            for (int i = 0; i < noSubjects; i++)
            {
                if (S[i])
                {
                    labelG[i] = labelG[i] - delta; // update labels for givers;
                }
            }

            for (int j = 0; j < noSubjects; j++)
            {
                if (T[j])
                {
                    labelR[j] = labelR[j] + delta; // update labels for receivers;
                }
            }

            for (int j = 0; j < noSubjects; j++)
            {
                if (!T[j])
                {
                    array[j] = array[j] - delta;
                }
            }
        }

        private void AddEdge(int i, int prev)
        {
            S[i] = true;
            path[i] = prev;

            for (int j = 0; j < noSubjects; j++)
            {
                if (labelG[i] + labelR[j] - costMatrix[i, j] < array[j])
                {
                    array[j] = labelG[i] + labelR[j] - costMatrix[i, j];
                    arrayX[j] = i;
                }
            }
        }

        public int Compute()
        {
            int result = 0;
            maxMatching = 0;

            gr = Enumerable.Repeat(-1, DIM).ToArray();
            rg = Enumerable.Repeat(-1, DIM).ToArray();

            InitializeFakeData();
            InitializeLabels();
            Augment();


            for (int i = 0; i < noSubjects; i++)
            {
                Console.WriteLine(i + " " + gr[i]);
                result = result + costMatrix[i, gr[i]];
            }

            for (int i = 0; i < DIM; i++)
            {
                Console.WriteLine(path[i]);
            }

            return result;
        }

        public void InitializeFakeData()
        {
            noSubjects = 3;

            costMatrix[0,0] = 40;
            costMatrix[0,1] = 60;
            costMatrix[0,2] = 15;

            costMatrix[1,0] = 25;
            costMatrix[1,1] = 30;
            costMatrix[1,2] = 45;

            costMatrix[2,0] = 55;
            costMatrix[2,1] = 30;
            costMatrix[2,2] = 25;




            for(int i=0;i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(costMatrix[i, j] + " ");
                }
                Console.Write("\n");

            }
        }

        public HungarianAlgorithm() { }
    }
}
