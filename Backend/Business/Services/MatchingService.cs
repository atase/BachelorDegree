
using AutoMapper;
using Business.Algorithms;
using Business.Models;
using DataAccess.Interfaces;
using Kidney.Business.Models;
using Kidney.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public class MatchingService : IMatchingService
    {
        IReceiverRepository _receiverRepository;
        IGiverRepository _giverRepository;
        ICompatibilityScoreRepository _compatibilityScoreRepository;
        IMapper _mapper;

        private Dictionary<int, Giver> giversDict = new Dictionary<int, Giver>();
        private Dictionary<int, Receiver> receiversDict = new Dictionary<int, Receiver>();

        public MatchingService(IReceiverRepository receiverRepository, IGiverRepository giverRepository, ICompatibilityScoreRepository compatibilityScoreRepository, IMapper mapper)
        {
            _receiverRepository = receiverRepository;
            _giverRepository = giverRepository;
            _compatibilityScoreRepository = compatibilityScoreRepository;
            _mapper = mapper;
        }

        public async Task<Matching> MaximalMatchingGiversToReceivers(int var, Compatibility<Giver, Receiver> compatibilities)
        {
            Matching matching = new Matching();

            var matrix = BuildMatrix(compatibilities);

            HungarianAlgorithm algorithm = new HungarianAlgorithm(matrix, Math.Max(giversDict.Count, receiversDict.Count));
            
            matching.MatchingValue = algorithm.Compute();

            List<Pair<Pair<Giver, Receiver>, int>> optimalAssigment = new List<Pair<Pair<Giver, Receiver>, int>>();

            var matchingResult = algorithm.GetMatchingAssigments();
            Giver giver;
            Receiver receiver;
            foreach (var item in matchingResult.Keys)
            {
                giversDict.TryGetValue(item.First, out giver);
                receiversDict.TryGetValue(item.Second, out receiver);
                int score = -1;
                matchingResult.TryGetValue(item, out score);



                optimalAssigment.Add(new Pair<Pair<Giver, Receiver>, int>
                {
                    First = new Pair<Giver, Receiver>
                    {
                        First = giver,
                        Second = receiver
                    },
                    Second = score != -1 ? score : 0
                });
            }

            matching.OptimalAssigment = optimalAssigment;


            return matching;
        }

        private int[,] BuildMatrix(Compatibility<Giver, Receiver> compatibilities)
        {

            int i = 0;
            int j = 0;
            
            

            foreach (var obj in compatibilities.CompatibilityScores)
            {
                if (!giversDict.ContainsValue(obj.First.First))
                {
                    giversDict.Add(i, obj.First.First);
                    i++;
                }

                if (!receiversDict.ContainsValue(obj.First.Second))
                {
                    receiversDict.Add(j, obj.First.Second);
                    j++;
                }
            }
            giversDict.OrderBy(key => key.Value);
            receiversDict.OrderBy(key => key.Value);
            int n = Math.Max(giversDict.Count, receiversDict.Count);
            int[,] matrix = new int[n, n];

            foreach (var p in compatibilities.CompatibilityScores)
            {
                var giverKey = giversDict.First(x => x.Value.Equals(p.First.First)).Key;
                var receiverKey = receiversDict.First(x => x.Value.Equals(p.First.Second)).Key;
                matrix[giverKey, receiverKey] = p.Second;
            }

            /*foreach (var g in compatibilities.CompatiblePairs)
            {
                var giverKey = giversDict.First(x => x.Value.Equals(g.First)).Key;

                foreach (var r in g.Second)
                {
                    var receiverKey = receiversDict.First(x => x.Value.Equals(r)).Key;
                    matrix[giverKey, receiverKey] = rand.Next(1, 11);
                }
            }*/

            for (i = 0; i < n; i++)
            {
                
                for (j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("\n");
            }

            return matrix;
        }

        private void HungarianAlgorithmVariant1() 
        {
            
        }

        /*public Task<Matching<Receiver, Giver>> MaximalMatchingReceiversToGivers(int var)
        {
            throw new NotImplementedException();
        }

        /*public MatchingDataDTO<GiverDTO, ReceiverDTO> Matching()
        {
            /*MatchingDataDTO<GiverDTO, ReceiverDTO> data = new MatchingDataDTO<GiverDTO, ReceiverDTO>();
            
            List<GiverDTO> giverDTOs = new List<GiverDTO>();
            List<ReceiverDTO> receiverDTOs = new List<ReceiverDTO>();
            List<CompatiblePairDTO<GiverDTO, ReceiverDTO>> compatiblePairs = new List<CompatiblePairDTO<GiverDTO, ReceiverDTO>>();


            List<Giver> givers = giverRepository.GetAll().Result;
            List<Receiver> receivers = receiverRepository.GetAll().Result;


            givers.ForEach(g => giverDTOs.Add(new GiverDTO
            {
                Id = g.Id,
                FirstName = g.FirstName,
                LastName = g.LastName
            }));

            receivers.ForEach(r => receiverDTOs.Add(new ReceiverDTO
            {
                Id = r.Id,
                FirstName = r.FirstName,
                LastName = r.LastName
            }));

            foreach (Giver giver in givers)
            {
                foreach (Receiver receiver in receivers)
                {
                    compatiblePairs.Add(new CompatiblePairDTO<GiverDTO, ReceiverDTO>() {
                        First = new GiverDTO 
                        {
                            Id = giver.Id,
                            FirstName = giver.FirstName,
                            LastName = giver.LastName
                        },
                        Second = new ReceiverDTO 
                        {
                            Id = receiver.Id,
                            FirstName = receiver.FirstName,
                            LastName = receiver.LastName
                        }
                    });
                }
            }

            data.CompatiblePairs = compatiblePairs;
            data.TElements = giverDTOs;
            data.UElements = receiverDTOs;

           Algorithm algorithm = new HungarianAlgorithmImpl();

            algorithm.Compatible = new int[givers.Count, receivers.Count];
            algorithm.MatchingSize = givers.Count;
            algorithm.GiversNo = givers.Count;
            algorithm.ReceiversNo = receivers.Count;

            int i = 0, j = 0;

            foreach (Giver giver in givers)
            {

                foreach (Receiver receiver in receivers)
                {
                    algorithm.Compatible[i, j] = 1;
                    j++;
                }
                i++;
                j = 0;
            }


            algorithm.Compute();

            return data;
        }*/
    }
}
