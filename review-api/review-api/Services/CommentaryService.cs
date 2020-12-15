using AutoMapper;
using ProyectoFinalTecWeb.Exceptions;
using review_api.Data.Entities;
using review_api.Data.Repository;
using review_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Services
{
    public class CommentaryService : ICommentaryService
    {

        private IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public CommentaryService(IReviewRepository reviewRepository, IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Commentary>> GetAllComments(int bookId)
        {
            string orderBy = "Id";
            var orderByToLower = orderBy.ToLower();
            var Commentaryentities = await reviewRepository.GetCommentsAsync(bookId);
            return mapper.Map<IEnumerable<Commentary>>(Commentaryentities);
        }

        public async Task<Commentary> GetCommentary(int id, int bookId)
        {
            var commentaryEntity = await reviewRepository.GetCommentaryAsync(id);
            if (commentaryEntity == null)
            {
                throw new NotFoundItemException("Commentary not found");
            }

            return mapper.Map<Commentary>(commentaryEntity);
        }

        public async Task<Commentary> UpdateCommentary(int id, int bookId, Commentary commentary)
        {
            if (id != commentary.Id)
            {
                throw new NotFoundItemException($"not found guest with id:{id}");
            }

            await ValidateCommentary(id);
            commentary.Id = id;
            commentary.BookId = bookId;
            var commentaryEntity = mapper.Map<CommentaryEntity>(commentary);
            reviewRepository.UpdateCommentaryAsync(commentaryEntity);
            if (await reviewRepository.SaveChangesAsync())
            {
                return mapper.Map<Commentary>(commentaryEntity);
            }
            throw new Exception("there were an error with the BD");
        }

        public async Task<Commentary> CreateCommentary(int bookId, Commentary commentary)
        {
            if (commentary.BookId != null && bookId != commentary.BookId)
            {
                throw new BadRequestOperationException("URL commentary id and Book.BookId should be equal");
            }

            commentary.BookId = bookId;
            var commentaryEntity = mapper.Map<CommentaryEntity>(commentary);
            reviewRepository.CreateCommentary(commentaryEntity);

            if (await reviewRepository.SaveChangesAsync())
            {
                return mapper.Map<Commentary>(commentaryEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteCommentary(int id)
        {
            await reviewRepository.DeleteCommentaryAsync(id);
            if (await reviewRepository.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }
       
        private async Task ValidateCommentary(int id)
        {
            var commentary = await reviewRepository.GetCommentaryAsync(id);
            if (commentary == null)
            {
                throw new NotFoundItemException("invalid commentary to delete");
            }
            reviewRepository.DetachEntity(commentary);
        }
    }
}
