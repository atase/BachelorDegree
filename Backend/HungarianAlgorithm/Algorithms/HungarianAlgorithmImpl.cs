using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HungarianAlgorithm.Algorithms
{
    public class HungarianAlgorithmImpl : Algorithm
    {

        private int optimalMatchingWeight;
        private int maxMatch;

        private int[] giversLabels;
        private int[] receiversLabels;
        private int[] prev;
        private int[] giverReceiver;
        private int[] receiverDonor;
        private int[] slack;
        private int[] slackX;

        private bool[] S;
        private bool[] T;

        private int[,] weight;


        public int[] Givers { get; set; }
        public int[] Receivers { get; set; }
        public int[,] Compatible { get; set; }
        public int MatchingSize { get; set; }
        public int GiversNo { get; set; }
        public int ReceiversNo { get; set; }

        public HungarianAlgorithmImpl()
        {
        }


        private void Augment() 
        {
            if (maxMatch == MatchingSize)
            {
                return;
            }

            int root = 0, giver = 0, receiver = 0;
            Queue q = new Queue();

            S = Enumerable.Repeat(false, MatchingSize).ToArray();
            T = Enumerable.Repeat(false, MatchingSize).ToArray();
            prev = Enumerable.Repeat(-1, MatchingSize).ToArray();

            for (int i = 0; i < MatchingSize; i++) 
            {
                if (giverReceiver[i] == -1) 
                {
                    root = i;
                    q.Enqueue(root);
                    prev[i] = -2;
                    S[i] = true;
                    break;
                }
            }

            for (int j = 0; j < MatchingSize; j++)
            {
                slack[j] = giversLabels[root] + receiversLabels[j] - weight[root, j];
                slackX[j] = root;
            }

            while (true)
            {
                while (q.Count != 0)
                {
                    giver = (int)q.Dequeue();
                    for (receiver = 0; receiver < MatchingSize; receiver++)
                    {
                        if (weight[giver, receiver] == giversLabels[giver] + receiversLabels[receiver] && !T[receiver])
                        {
                            if (receiverDonor[receiver] == -1) break;
                            T[receiver] = true;
                            q.Enqueue(receiverDonor[receiver]);
                            AddToTree(receiverDonor[receiver], giver);
                        }
                    }

                    if (receiver < MatchingSize) break;
                }

                if (receiver < MatchingSize) break;

                UpdateLabels();


                for (receiver = 0; receiver < MatchingSize; receiver++)
                {
                    if (!T[receiver] && slack[receiver] == 0)
                    {
                        if (receiverDonor[receiver] == -1)
                        {
                            giver = slackX[receiver];
                            break;
                        }
                        else
                        {
                            T[receiver] = true;
                            if (!S[receiverDonor[receiver]])
                            {
                                q.Enqueue(receiverDonor[receiver]);
                                AddToTree(receiverDonor[receiver], slackX[receiver]);
                            }
                        }
                    }
                }
                if (receiver < MatchingSize) break;
            }

            if (receiver < MatchingSize)
            {
                maxMatch++;
                for (int cGiver = giver, cReceiver = receiver, temp; cGiver != -2; cGiver = prev[cGiver], cReceiver = temp)
                {
                    temp = giverReceiver[cGiver];
                    receiverDonor[cReceiver] = cGiver;
                    giverReceiver[cGiver] = cReceiver;
                }
                Augment();
            }

        }

        private void UpdateLabels() 
        {
            int delta = int.MaxValue;
            for (int j = 0; j < MatchingSize; j++)
            {
                if (!T[j])
                {
                    delta = Math.Min(delta, slack[j]);
                }
            }


            for(int i=0;i<MatchingSize;i++)
            {
                if (S[i])
                {
                    giversLabels[i] -= delta;
                }
            }

            for (int j = 0; j < MatchingSize; j++)
            {
                if (T[j])
                {
                    receiversLabels[j] += delta;
                }
            }

            for (int j = 0; j < MatchingSize; j++)
            {
                if (!T[j])
                {
                    slack[j] -= delta;
                }
            }

        }


        private void AddToTree(int giver, int prevDonnor)
        {
            S[giver] = true;
            prev[giver] = prevDonnor;
            for (int receiver = 0; receiver < MatchingSize; receiver++)
            {
                int result = giversLabels[receiver] + receiversLabels[receiver] - weight[giver, receiver];
                if ( result < slack[receiver])
                {
                    slack[receiver] = result;
                    slackX[receiver] = giver;
                }
            }
        }

        private void InitializeWeight()
        {
            for (int i = 0; i < GiversNo; i++) 
            {
                for (int j = 0; j < ReceiversNo; j++)
                {
                    if (Compatible[i, j] == 1)
                    {
                        weight[i, j] = i + j;
                    }

                    giversLabels[i] = Math.Max(giversLabels[i], weight[i, j]);
                }
            }

            giverReceiver = Enumerable.Repeat(-1, ReceiversNo).ToArray();
            receiverDonor = Enumerable.Repeat(-1, GiversNo).ToArray();



        }

        private void WriteCompatibleAssigment()
        {
            for (int i = 0; i < GiversNo; i++)
            {
                for (int j = 0; j < ReceiversNo; j++) 
                {
                    Console.Write(i + " " + j + " => " +  Compatible[i, j] + " ");
                }
                Console.Write("\n");

            }
        }

        private void WriteWeight()
        {
            for (int i = 0; i < GiversNo; i++)
            {
                for (int j = 0; j < ReceiversNo; j++)
                {
                    Console.Write(weight[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        public void Compute()
        {
            optimalMatchingWeight = 0;
            maxMatch = 0;
            giversLabels = Enumerable.Repeat(0, GiversNo).ToArray();
            receiversLabels = Enumerable.Repeat(0, ReceiversNo).ToArray();
            weight = new int[GiversNo, ReceiversNo];

            slack = new int[MatchingSize];
            slackX = new int[MatchingSize];



            WriteCompatibleAssigment();


            InitializeWeight();
            Augment();

            for (int giver = 0; giver < GiversNo; giver++)
            {
                optimalMatchingWeight += weight[giver, giverReceiver[giver]];
            }

            Console.WriteLine(optimalMatchingWeight);


           // WriteWeight();
           // WriteCompatibleAssigment();
        }
    }
}
