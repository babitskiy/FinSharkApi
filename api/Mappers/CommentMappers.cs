using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
            => new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };

        public static Comment ToCommentFromCreate(this CreateCommentDto createCommentDto, int stockId)
            => new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId,
            };

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto updateCommentDto)
            => new Comment
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content,
            };
    }
}