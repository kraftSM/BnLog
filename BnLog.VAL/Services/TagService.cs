using AutoMapper;
using BnLog.VAL.Services.IService;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.VAL.Request.Entity;
using BnLog.DAL.Models.Security;
using Microsoft.AspNetCore.Identity;
using BnLog.VAL.Request.Entity;
using Microsoft.EntityFrameworkCore;


namespace BnLog.VAL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepo;
        private IMapper _mapper;

        public TagService(ITagRepository repo, IMapper mapper)
        {
            _tagRepo = repo;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTag(TagCreateRequest model)
        {
            var tag = _mapper.Map<Tag>(model);
            ////Поиск существующего Tag
            //var inBaseTag = _tagRepo.GetAllTags().FirstOrDefault(t => t.Name == tag.Name);
            //if (inBaseTag != null)
            //    return inBaseTag.Id;

            await _tagRepo.AddTag(tag);
            return tag.Id;
        }
        public async Task<Tag> GetTag(Guid id)
        {
            var tag = _tagRepo.GetTag(id);

            return tag;
        }
        public async Task EditTag(Guid id)
        {
            var tag = _tagRepo.GetTag(id);
            //return tag;
        }
        public async Task EditTag(TagEditRequest model)
        {
            if (string.IsNullOrEmpty(model.Name))
                return;

            var tag = _tagRepo.GetTag(model.Id);
            tag.Name = model.Name;
            await _tagRepo.UpdateTag(tag);
        }

        public async Task RemoveTag(Guid id)
        {
            await _tagRepo.RemoveTag(id);
        }

        public async Task<List<Tag>> GetTags()
        {
            return _tagRepo.GetAllTags().ToList();
        }
    }
}
