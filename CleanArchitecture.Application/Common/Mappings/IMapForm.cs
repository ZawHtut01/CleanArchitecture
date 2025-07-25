﻿using AutoMapper;

namespace CleanArchitecture.Application.Common.Mappings
{
    public interface IMapForm<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T),GetType());
    }
}
