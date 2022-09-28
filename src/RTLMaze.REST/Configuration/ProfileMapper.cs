using AutoMapper;
using RTLMaze.Models;
using RTLMaze.REST.Dto;

namespace RTLMaze.REST.Configuration;

public class ProfileMapper : Profile
{
	public ProfileMapper()
	{
		CreateMap<Title, TitleDto>();
	}
}