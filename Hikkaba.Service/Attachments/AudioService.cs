﻿using System.Linq;
using AutoMapper;
using Hikkaba.Data.Context;
using Hikkaba.Data.Entities.Attachments;
using Hikkaba.Models.Dto.Attachments;
using Hikkaba.Service.Base.Current;
using Microsoft.EntityFrameworkCore;

namespace Hikkaba.Service.Attachments
{
    public interface IAudioService : IBaseImmutableEntityService<AudioDto, Audio>{}

    public class AudioService: BaseImmutableEntityService<AudioDto, Audio>, IAudioService
    {
        public AudioService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }

        protected override DbSet<Audio> GetDbSet(ApplicationDbContext context)
        {
            return context.Audio;
        }

        protected override IQueryable<Audio> GetDbSetWithReferences(ApplicationDbContext context)
        {
            return context.Audio.Include(audio => audio.Post);
        }
    }
}