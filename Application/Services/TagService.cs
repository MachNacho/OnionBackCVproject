﻿using Application.Contracts;
using Domain.Contracts;
using Domain.Entities;

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

        public Task<bool> DeleteTag(int id)
        {
            return _tagRepository.Delete(id);
        }

        public Task<Tag> UpdateTag(int id, Tag tag)
        {
            return _tagRepository.Update(id, tag);
        }
    }
}
