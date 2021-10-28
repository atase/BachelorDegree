using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HungarianAlgorithm.Algorithms
{
    class HungarianAlgorithmImpl : Algorithm
    {

        private int optimalMatchingWeight;

        private const int rowNo = 5;
        private const int colNo = 5;

        private const int n = 5;
        private int maxMatch;

        private int[] donorsLabels = Enumerable.Repeat(0, n).ToArray();
        private int[] receiversLabels = Enumerable.Repeat(0, n).ToArray();
        private int[] prev;
        private int[] donorReceiver;
        private int[] receiverDonor;
        private int[] slack = new int[n];
        private int[] slackX = new int[n];

        private bool[] S;
        private bool[] T;

        private int[,] weight = new int[5, 5];
        private int[] donors = new int[] { 1, 2, 3, 4, 5 };
        private int[] receivers = new int[] { 1, 2, 3, 4, 5 };
        private int[,] compatible = new int[5, 5] { { 1, 1, 1, 1, 1 },
                                                    { 1, 1, 1, 1, 1 },
                                                    { 1, 1, 1, 1, 1 },
                                                    { 1, 1, 1, 1, 1 },
                                                    { 1, 1, 1, 1, 1 }
                                                    };


        public HungarianAlgorithmImpl()
        {
        }


        private void Augment() 
        {
            if (maxMatch == n)
            {
                return;
            }

            int root = 0, donnor = 0, receiver = 0;
            Queue q = new Queue();

            S = Enumerable.Repeat(false, n).ToArray();
            T = Enumerable.Repeat(false, n).ToArray();
            prev = Enumerable.Repeat(-1, n).ToArray();

            for (int i = 0; i < n; i++) 
            {
                if (donorReceiver[i] == -1) 
                {
                    root = i;
                    q.Enqueue(root);
                    prev[i] = -2;
                    S[i] = true;
                    break;
                }
            }

            for (int j = 0; j < n; j++)
            {
                slack[j] = donorsLabels[root] + receiversLabels[j] - weight[root, j];
                slackX[j] = root;
            }

            while (true)
            {
                while (q.Count != 0)
                {
                    donnor = (int)q.Dequeue();
                    for (receiver = 0; receiver < n; receiver++)
                    {
                        if (weight[donnor, receiver] == donorsLabels[donnor] + receiversLabels[receiver] && !T[receiver])
                        {
                            if (receiverDonor[receiver] == -1) break;
                            T[receiver] = true;
                            q.Enqueue(receiverDonor[receiver]);
                            AddToTree(receiverDonor[receiver], donnor);
                        }
                    }

                    if (receiver < n) break;
                }

                if (receiver < n) break;

                UpdateLabels();


                for (receiver = 0; receiver < n; receiver++)
                {
                    if (!T[receiver] && slack[receiver] == 0)
                    {
                        if (receiverDonor[receiver] == -1)
                        {
                            donnor = slackX[receiver];
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
                if (receiver < n) break;
            }

            if (receiver < n)
            {
                maxMatch++;
                for (int cDonnor = donnor, cReceiver = receiver, temp; cDonnor != -2; cDonnor = prev[cDonnor], cReceiver = temp)
                {
                    temp = donorReceiver[cDonnor];
                    receiverDonor[cReceiver] = cDonnor;
                    donorReceiver[cDonnor] = cReceiver;
                }
                Augment();
            }

        }

        private void UpdateLabels() 
        {
            int delta = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (!T[j])
                {
                    delta = Math.Min(delta, slack[j]);
                }
            }


            for(int i=0;i<n;i++)
            {
                if (S[i])
                {
                    donorsLabels[i] -= delta;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (T[j])
                {
                    receiversLabels[j] += delta;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (!T[j])
                {
                    slack[j] -= delta;
                }
            }

        }


        private void AddToTree(int donnor, int prevDonnor)
        {
            S[donnor] = true;
            prev[donnor] = prevDonnor;
            for (int receiver = 0; receiver < n; receiver++)
            {
                int result = donorsLabels[receiver] + receiversLabels[receiver] - weight[donnor, receiver];
                if ( result < slack[receiver])
                {
                    slack[receiver] = result;
                    slackX[receiver] = donnor;
                }
            }
        }

        private void InitializeWeight()
        {
            for (int i = 0; i < rowNo; i++) 
            {
                for (int j = 0; j < colNo; j++)
                {
                    if (compatible[i, j] == 1)
                    {
                        weight[i, j] = i + j;
                    }

                    donorsLabels[i] = Math.Max(donorsLabels[i], weight[i, j]);
                }
            }

            donorReceiver = Enumerable.Repeat(-1, n).ToArray();
            receiverDonor = Enumerable.Repeat(-1, n).ToArray();


            
        }

        private void WriteCompatibleAssigment()
        {
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++) 
                {
                    Console.Write(compatible[i, j] + " ");
                }
                Console.Write("\n");

            }
        }

        private void WriteWeight()
        {
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                    Console.Write(weight[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        public void Start()
        {
            optimalMatchingWeight = 0;
            maxMatch = 0;
            donorReceiver = Enumerable.Repeat(-1, n).ToArray();
            receiverDonor = Enumerable.Repeat(-1, n).ToArray();

            InitializeWeight();
            Augment();

            for (int donor = 0; donor < n; donor++)
            {
                optimalMatchingWeight += weight[donor, donorReceiver[donor]];
            }

            Console.WriteLine(optimalMatchingWeight);


            WriteWeight();
            WriteCompatibleAssigment();
        }
    }
}
