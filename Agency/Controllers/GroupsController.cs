using Agency.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IGroupMemberService _groupMemberService;
        private readonly ITourService _tourService;

        private readonly IMapper _mapper;
        public GroupsController(IGroupService groupService, IGroupMemberService groupMemberService,IMapper mapper)
        {
            _groupMemberService = groupMemberService;
            _groupService = groupService;
            _mapper = mapper;
        }
        public async Task<IActionResult> AllGroups()
        {
            var groups = _mapper.Map<List<ModelGroup>>(await _groupService.GetAllAsync());
            return View(groups);
        }

        public async Task<IActionResult> ShowParticipants(int groupId)
        {
           var group= await _groupService.GetByIdAsync(groupId);
            var members = group.GroupMembers;
          
            var users = new List<UserDTO>();

            foreach (var member in members)
            {
                users.Add(member.ApplicationUser);
            }
            var musers=_mapper.Map<List<ModelUser>>(users);
            return View(musers);
        }
    }
}
