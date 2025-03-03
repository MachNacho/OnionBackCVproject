﻿using Application.Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public Task<Tag> AddTag(Tag tag)
        {
            return _tagRepository.Add(tag);
        }

        public Task<Tag> DeleteTag(int id)
        {
            return _tagRepository.Delete(id);
        }

        public Task<Tag> UpdateTag(int id, Tag tag)
        {
            return _tagRepository.Update(id, tag);
        }
    }
}
