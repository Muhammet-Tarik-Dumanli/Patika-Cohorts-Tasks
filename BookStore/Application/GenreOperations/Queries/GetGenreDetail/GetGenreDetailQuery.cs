using System;
using System.Linq;
using AutoMapper;
using BookStore.DbOperations;

namespace BookStore.Application.GenreOpereations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if(genre == null)
                throw new InvalidOperationException("Kitap türü bulunamadı!");
                
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}