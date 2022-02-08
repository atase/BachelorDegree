using AutoMapper;
using Business.Models;
using DataAccess.DTOs;
using DataAccess.Interfaces;
using Kidney.Business.Models;
using Kidney.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public class CompatibilityService : ICompatibilityService
    {

        private IGiverRepository _giverRepository;
        private IReceiverRepository _receiverRepository;
        private ICompatibilityScoreRepository _compatibilityScoreRepository;
        private IMapper _mapper;

        public CompatibilityService(
            IGiverRepository giverRepository,
            IReceiverRepository receiverRepository,
            ICompatibilityScoreRepository compatibilityScoreRepository,
            IMapper mapper)
        {
            _giverRepository = giverRepository ?? throw new ArgumentNullException(nameof(giverRepository));
            _receiverRepository = receiverRepository ?? throw new ArgumentNullException(nameof(receiverRepository));
            _compatibilityScoreRepository = compatibilityScoreRepository ?? throw new ArgumentNullException(nameof(compatibilityScoreRepository));
            _mapper = mapper;

        }

        public async Task<Compatibility<Giver, Receiver>> GetCompatibilitiesForGiver(int id)
        {

            var giverScores = await _compatibilityScoreRepository.GetScoresForGiver(id);

            Compatibility<Giver, Receiver> compatibility = new Compatibility<Giver, Receiver>();


            Giver giver = _mapper.Map<Giver>(await _giverRepository.GetById(id));
            compatibility.SubjectCompatibility.First = giver;

            List<Receiver> receivers = new List<Receiver>();

            foreach (var item in giverScores)
            {
                receivers.Add(_mapper.Map<Receiver>(await _receiverRepository.GetById(item.ReceiverId)));
            }

            compatibility.SubjectCompatibility.Second = receivers;
            return compatibility;
        }

        public async Task<Compatibility<Giver, Receiver>> GetCompatibilitiesForGivers()
        {

            Compatibility<Giver, Receiver> compatibility = new Compatibility<Giver, Receiver>();
            IEnumerable<Receiver> receivers = _mapper.Map<IEnumerable<Receiver>>(await _receiverRepository.GetAll());
            IEnumerable<Giver> givers = _mapper.Map<IEnumerable<Giver>>(await _giverRepository.GetAll());

            List<Pair<Giver, IEnumerable<Receiver>>> results = new List<Pair<Giver, IEnumerable<Receiver>>>();

            foreach (var giver in givers)
            {

                var compatibleSubjects = new List<Receiver>();

                foreach (var receiver in receivers)
                {
                    if (DefineCompatibility(giver, receiver))
                    {
                        compatibleSubjects.Add(receiver);
                    }
                }

                var compatiblePair = new Pair<Giver, IEnumerable<Receiver>>(giver, compatibleSubjects);
                results.Add(compatiblePair);
            }
            compatibility.CompatiblePairs = results;

            return compatibility;
        }

        public async Task<Compatibility<Receiver, Giver>> GetCompatibilitiesForReceiver(int id)
        {

            var compatibilitiesScores = _compatibilityScoreRepository.GetScoresForReceiver(id);

            Compatibility<Receiver, Giver> compatibility = new Compatibility<Receiver, Giver>();
            Receiver receiver = _mapper.Map<Receiver>(await _receiverRepository.GetById(id));
            compatibility.SubjectCompatibility.First = receiver;

            IEnumerable<Giver> givers = _mapper.Map<IEnumerable<Giver>>(await _giverRepository.GetAll());
            List<Giver> compatibleSubjects = new List<Giver>();

            foreach (var giver in givers)
            {
                if (DefineCompatibility(giver, receiver))
                {
                    compatibleSubjects.Add(giver);
                }
            }
            compatibility.SubjectCompatibility.Second = compatibleSubjects;
            return compatibility;
        }

        public async Task<Compatibility<Receiver, Giver>> GetCompatibilitiesForReceivers()
        {
            Compatibility<Receiver, Giver> compatibility = new Compatibility<Receiver, Giver>();
            IEnumerable<Receiver> receivers = _mapper.Map<IEnumerable<Receiver>>(await _receiverRepository.GetAll());
            IEnumerable<Giver> givers = _mapper.Map<IEnumerable<Giver>>(await _giverRepository.GetAll());

            List<Pair<Receiver, IEnumerable<Giver>>> results = new List<Pair<Receiver, IEnumerable<Giver>>>();

            foreach (var receiver in receivers)
            {

                var compatibleSubjects = new List<Giver>();

                foreach (var giver in givers)
                {
                    if (DefineCompatibility(giver, receiver))
                    {
                        compatibleSubjects.Add(giver);
                    }
                }

                var compatiblePair = new Pair<Receiver, IEnumerable<Giver>>(receiver, compatibleSubjects);
                results.Add(compatiblePair);
            }
            compatibility.CompatiblePairs = results;

            return compatibility;
        }


        public async Task<Compatibility<Giver, Receiver>> GenerateCompatibilityScores() 
        {

            IEnumerable<Giver> givers = _mapper.Map<IEnumerable<Giver>>(await _giverRepository.GetAll());
            IEnumerable<Receiver> receivers = _mapper.Map<IEnumerable<Receiver>>(await _receiverRepository.GetAll());

            List<CompatibilityScoreDto> scores = new List<CompatibilityScoreDto>();


            foreach (var g in givers)
            {
                foreach (var r in receivers)
                {
                    scores.Add(GenerateScores(g, r));

                }
            }

            await _compatibilityScoreRepository.InsertScore(scores);

            return await GetCompatibilityScores();
        }

        public async Task<Compatibility<Giver, Receiver>> GetCompatibilityScores()
        {
            Compatibility<Giver, Receiver> compatibility = new Compatibility<Giver, Receiver>();
            List<Pair<Pair<Giver, Receiver>, int>> compatibilityScores = new List<Pair<Pair<Giver, Receiver>, int>>();

            var scores = await _compatibilityScoreRepository.GetAll();

            foreach (var score in scores)
            {
                compatibilityScores.Add(new Pair<Pair<Giver, Receiver>, int>()
                {
                    First = new Pair<Giver, Receiver>()
                    {
                        First = _mapper.Map<Giver>(await _giverRepository.GetById(score.GiverId)),
                        Second = _mapper.Map<Receiver>(await _receiverRepository.GetById(score.ReceiverId))
                    },
                    Second = score.Score
                });
            }

            compatibility.CompatibilityScores = compatibilityScores;
            return compatibility;
        }


        public async Task<Statistics> GetStatistics()
        {
            Statistics statistics = new Statistics()
            {
                NumberOfGivers = (await _giverRepository.GetAll()).Count,
                NumberOfReceivers = (await _receiverRepository.GetAll()).Count,
            };

            statistics.NumberOfSubjects = statistics.NumberOfGivers + statistics.NumberOfReceivers;

            return statistics;
        }

        private CompatibilityScoreDto GenerateScores(Giver giver, Receiver receiver)
        {
            var result = new CompatibilityScoreDto();
            var score = 0;
            var rand = new Random();

            if (DefineCompatibility(giver, receiver))
            {
                score = rand.Next(1, 11);
            }

            result.ReceiverId = receiver.Id;
            result.GiverId = giver.Id;
            result.Score = score;

            return result;
        }

        private bool DefineCompatibility(Giver giver, Receiver receiver)
        {
            return BloodTypeCompatibility(giver, receiver);
        }

        private bool BloodTypeCompatibility(Giver giver, Receiver receiver)
        {
            if (giver.BloodType.Equals(receiver.BloodType))
            {
                return true;
            }

            if (giver.BloodType.Equals("O"))
            {
                return true;
            }

            if (giver.BloodType.Equals("A") && receiver.BloodType.Equals("AB"))
            {
                return true;
            }

            if (giver.BloodType.Equals("B") && receiver.BloodType.Equals("AB"))
            {
                return true;
            }

            return false;
        }
    }
}
