using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using neogym.business.Exceptions;
using neogym.business.Extentions;
using neogym.core.Models;
using neogym.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace neogym.business.Servicecs.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IWebHostEnvironment _env;

        public TrainerService(ITrainerRepository trainerRepository
                             ,IWebHostEnvironment env)
        {
            _trainerRepository = trainerRepository;
           _env = env;
        }
        public async Task CreateAsync(Trainer trainer)
        {
            if (trainer == null)
            {
                throw new NullReferenceException();
            }
            if (trainer.ImageFile == null)
            {
                if (trainer.ImageFile.ContentType != "image/png" && trainer.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentException("ImageFile", "file must be ower than .png or .jpeg");
                }
                if (trainer.ImageFile.Length > 2077168)
                {
                    throw new InvalidImageSizeException("ImageFile", "File must be lower than 2mb");
                }
               
            }
            trainer.ImageUrl = trainer.ImageFile.SaveFile(_env.WebRootPath, "uploads/trainers");
            trainer.CreatedDate= DateTime.UtcNow;
            trainer.UpdatedDate = DateTime.UtcNow;
            trainer.IsDeleted=false;
            await _trainerRepository.CreateAsync(trainer);
           await _trainerRepository.CommitAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var existtrainer=await _trainerRepository.GetByIdAsync(x=>x.Id==id);
            if (existtrainer == null)
            {
                throw new NullReferenceException();
            }
            _trainerRepository.Delete(existtrainer);
            await _trainerRepository.CommitAsync();
              

        }

        public async Task<List<Trainer>> GetAllAsync()
        {
           return await _trainerRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Trainer> GetByIdAsync(int id)
        {
            var existtrainer = await _trainerRepository.GetByIdAsync(x => x.Id == id);
            if (existtrainer == null)
            {
                throw new NullReferenceException();
            }

            return existtrainer;
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            var existtrainer = await _trainerRepository.GetByIdAsync(x => x.Id == trainer.Id);
            if(existtrainer == null)
            {
                throw new NullReferenceException();
            }
            if (trainer == null)
            {
                throw new NullReferenceException();
            }
            if (trainer.ImageFile == null)
            {
                if (trainer.ImageFile.ContentType != "image/png" && trainer.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentException("ImageFile", "file must be ower than .png or .jpeg");
                }
                if (trainer.ImageFile.Length > 2077168)
                {
                    throw new InvalidImageSizeException("ImageFile", "File must be lower than 2mb");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/trainers", trainer.ImageUrl);
                existtrainer.ImageUrl = trainer.ImageFile.SaveFile(_env.WebRootPath, "uploads/trainers");
            }
            existtrainer.IsDeleted = false;
            existtrainer.Name=trainer.Name;
            existtrainer.InstaUrl=trainer.InstaUrl;
            existtrainer.FbUrl=trainer.FbUrl;
            existtrainer.TwitterUrl=trainer.TwitterUrl;
            existtrainer.UpdatedDate=DateTime.UtcNow;
            await _trainerRepository.CommitAsync();


        }
    }
}
