using Library.Application.Common.Mappings;
using System.Collections.Generic;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class AuthorListVm
    {
        public List<AuthorDto> Authors { get; set; }
    }
}