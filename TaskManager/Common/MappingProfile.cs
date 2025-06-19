using AutoMapper;
using System.Runtime;
using TaskManager.Dto;
using TaskManager.Model;

namespace TaskManager.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //source and designation
            CreateMap<Tasks,TaskItemDto>().ReverseMap();
        }

    }
}
