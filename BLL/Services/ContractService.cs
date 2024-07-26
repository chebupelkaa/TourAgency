
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    internal class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractService(IMapper mapper, IContractRepository contractRepository)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }
        public async Task<ContractDTO> CreateAsync(ContractDTO entity)
        {
            var mappedEntity = _mapper.Map<Contract>(entity);
         
            mappedEntity.Reservation = null;
            
            await _contractRepository.CreateAsync(mappedEntity);
            return entity;
        }

        public Task<ContractDTO> DeleteAsync(ContractDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContractDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ContractDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContractDTO> UpdateAsync(ContractDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
