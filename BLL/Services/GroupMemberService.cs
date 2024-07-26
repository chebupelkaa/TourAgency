using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;


namespace BLL.Services
{
    internal class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IMapper _mapper;

        public GroupMemberService(IMapper mapper, IGroupMemberRepository groupMemberRepository)
        {
            _mapper = mapper;
            _groupMemberRepository = groupMemberRepository;
        }
        public Task<GroupMemberDTO> CreateAsync(GroupMemberDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<GroupMemberDTO> DeleteAsync(GroupMemberDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupMemberDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GroupMemberDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupMemberDTO> UpdateAsync(GroupMemberDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
