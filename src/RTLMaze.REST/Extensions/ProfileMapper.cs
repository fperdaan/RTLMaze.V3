using AutoMapper;
using RTLMaze.Models;
using RTLMaze.REST.Dto;

namespace RTLMaze.REST.Extensions;

public class ProfileMapper : Profile
{
	public ProfileMapper()
	{
		CreateMap<Title, TitleDto>();
	}
}