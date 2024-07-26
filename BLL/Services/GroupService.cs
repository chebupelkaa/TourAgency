using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupService(IMapper mapper, IGroupRepository groupRepository, IGroupMemberRepository groupMemberRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupMemberRepository = groupMemberRepository;
            _userManager = userManager;
        }
        public Task<GroupDTO> CreateAsync(GroupDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupDTO>> GetAllAsyncByTourId(int tourId)
        {
            //var tours = _mapper.Map<IEnumerable<TourDTO>>(await _tourRepository.GetAllAsync());
            var allGroups= await _groupRepository.GetAllAsync();
            var searched = allGroups.Where(t => t.TourId == tourId);
            var result = _mapper.Map<IEnumerable<GroupDTO>>(searched);
            return result;
        }
        public Task<GroupDTO> DeleteAsync(GroupDTO entity)
        {
            throw new NotImplementedException();
        }
        public async Task AddToGroup(int tourId,string userId)
        {
           
            var group =await _groupRepository.GetByTourId(tourId);
            if (group == null)
            {
                var entity = new Group();
                entity.TourId = tourId;
                entity.Tour = null;
                await _groupRepository.CreateAsync(entity);
                group=await _groupRepository.GetByTourId(tourId);
            }

            var groupmember = new GroupMember();

            groupmember.ApplicationUser = await _userManager.FindByIdAsync(userId);
            groupmember.GroupId = group.Id;
            groupmember.Group = null;
            await _groupMemberRepository.CreateAsync(groupmember);
            return;
        }
        public async Task<IEnumerable<GroupDTO>> GetAllAsync()
        {
            var groups = _mapper.Map<IEnumerable<GroupDTO>>(await _groupRepository.GetAllAsync());
            return groups;
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var entity = await _groupRepository.GetByIdAsync(id);
            var group = _mapper.Map<GroupDTO>(entity);
            return group;
        }

        public Task<GroupDTO> UpdateAsync(GroupDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
