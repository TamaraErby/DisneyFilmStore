using DisneyFilmStore.Data;
using DisneyFilmStore.Models.FilmModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Services
{
    class FilmService
    {
        private readonly Guid _userId;

        public FilmService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFilm(FilmCreate model)
        {
            var entity =
                new Film()
                {
                    FilmId = model.FilmId,
                    AuthorId = _userId,
                    Title = model.Title,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Films.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FilmListItem> GetFilms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Films
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new FilmListItem
                                {
                                    FilmId = e.FilmId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
                                }

                        );
                return query.ToArray();
            }
        }

        public FilmDetail GetFilmById(int id)
        {
            var filmService = new FilmService(_userId);
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Films
                        .Single(e => e.PostId == id && e.AuthorId == _userId);

                var films = filmService.GetFilmsByFilmId(entity.FilmId);

                return
                    new FilmDetail
                    {
                        FilmId = entity.FilmId,
                        AuthorId = entity.AuthorId,
                        Title = entity.Title,
                        Genre = entity.Genre,
                        MemberCost = entity.MemberCost,
                        NonMemberCost = entity.NonMemberCost,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }
        }


        public bool UpdateFilm(FilmEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Films
                        .Single(e => e.PostId == model.FilmId && e.AuthorId == _userId);

                entity.Title = model.Title;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Films
                        .Single(e => e.PostId == postId && e.AuthorId == _userId);

                ctx.Films.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
