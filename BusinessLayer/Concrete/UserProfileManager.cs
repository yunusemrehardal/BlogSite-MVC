using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserProfileManager
	{
		Repository<Author> repoUser = new Repository<Author>();
		Repository<Blog> repoUserBlog = new Repository<Blog>();
		public List<Author> GetAuthorByMail(string p)
		{
			return repoUser.List(x => x.Mail == p);
		}
		public List<Blog> GetBlogByAuthor(int id)
		{
			return repoUserBlog.List(x => x.AuthorId == id);
		}
	}
}
