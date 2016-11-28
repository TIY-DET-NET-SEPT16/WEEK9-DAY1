using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWithAuth.Models
{
    public static class Movies
    {
        public static void CreateMovie(Movie movy, MovieUser movieUser)
        {
            MovieAuthEntities db = new MoviesWithAuth.MovieAuthEntities();

            Movie checkMovie = (from m in db.Movies
                               where m.MovieName == movy.MovieName
                               select m).FirstOrDefault();

            if (checkMovie == null)
            {
                db.Movies.Add(movy);
                db.SaveChanges();
                checkMovie = db.Movies.Where(m => m.MovieName == movy.MovieName).FirstOrDefault();
            }

            movieUser.MovieId = checkMovie.MovieId;
            db.MovieUsers.Add(movieUser);
            db.SaveChanges();
        }

        public static IEnumerable<Movie> GetMoviesByUserName(string userName)
        {
            MovieAuthEntities db = new MoviesWithAuth.MovieAuthEntities();

            var myMovies = from movUsesr in db.MovieUsers
                           join mov in db.Movies on movUsesr.MovieId equals mov.MovieId
                           where movUsesr.UserName == userName
                           select mov;

            return myMovies;
        }

        public static void DeleteMovieFromUser(string userName, int movieId)
        {
            using (MovieAuthEntities db = new MoviesWithAuth.MovieAuthEntities())
            {
                var movUserToDelete = (from mu in db.MovieUsers
                                      where mu.MovieId == movieId && mu.UserName == userName
                                      select mu).FirstOrDefault();

                if (movUserToDelete != null)
                {
                    db.MovieUsers.Remove(movUserToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
