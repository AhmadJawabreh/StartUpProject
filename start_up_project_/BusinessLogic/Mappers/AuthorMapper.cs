using Entities;
using Models;
using Resources;
using System.Collections.Generic;

namespace BusinessLogic.Mappers
{
    class AuthorMapper
    {

        public static List<AuthorResource> ToResources(IEnumerable<Author> authors)
        {
            List<AuthorResource> AuthorResourcess = new List<AuthorResource>();

            foreach (var author in authors)
            {
                AuthorResourcess.Add(
                    new AuthorResource
                    {
                        Id = author.Id,
                        Email = author.Email,
                        Name = author.Name,
                        DateOfBirth = author.DateOfBirth

                    }
                  );
            }
            return AuthorResourcess;
        }


        public static AuthorResource ToResource(Author author)
        {
            AuthorResource authorResource = new AuthorResource();
            authorResource.Id = author.Id;
            authorResource.Name = author.Name;
            authorResource.Email = author.Email;
            authorResource.DateOfBirth = author.DateOfBirth;
            return authorResource;
        }


        public static Author ToEntity(Author author, AuthorModel authorModel)
        {
            author.Email = authorModel.Email;
            author.DateOfBirth = authorModel.DateOfBirth;
            author.Name = authorModel.Name.Trim();
            return author;
        }

    }
}
