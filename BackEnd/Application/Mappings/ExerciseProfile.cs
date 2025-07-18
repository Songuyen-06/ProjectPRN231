﻿using AutoMapper;
using EduCore.BackEnd.Application.DTOs;
using EduCore.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.BackEnd.Application.Mappings
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDTO>()
              .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
              .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.ExerciseUrl, opt => opt.MapFrom(src => src.ExerciseUrl))
              .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions)).ReverseMap();
        }
    }
}
