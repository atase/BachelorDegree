
using HungarianAlgorithm.Algorithms;
using Kidney.Business.Models;
using Kidney.DataAccess.DTOs;
using Kidney.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Kidney.Business.Services
{
    public class MatchingService : IMatchingService
    {
        IReceiverRepository receiverRepository;
        IGiverRepository giverRepository;


        public MatchingService(IGiverRepository _giverRepository, IReceiverRepository _receiverRepository) 
        {
            giverRepository = _giverRepository;
            receiverRepository = _receiverRepository;
        }

        public bool Compatible(Giver giver, Receiver receiver)
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
