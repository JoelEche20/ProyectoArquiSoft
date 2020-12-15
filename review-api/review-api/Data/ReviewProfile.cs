using AutoMapper;
using review_api.Data.Entities;
using review_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Data
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            this.CreateMap<CommentaryEntity, Commentary>()
                .ReverseMap();
        }
    }
}
