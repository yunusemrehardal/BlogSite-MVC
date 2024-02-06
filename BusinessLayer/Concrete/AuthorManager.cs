using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AuthorManager
	{
		Repository<Author> repoAuthor = new Repository<Author>();
		public List<Author> GetAll()
		{
			return repoAuthor.List();
		}
		public int AddAuthorBL(Author p)
		{
			if (p.AuthorName == "" || p.AboutShort == "" || p.AuthorTitle == "")
			{
				return -1;
			}
			return repoAuthor.Insert(p);
		}
		public Author FindAuthor(int id)
		{
			return repoAuthor.Find(x => x.AuthorId == id);
		}
		public int EditAuthor(Author p)
		{
			Author author = repoAuthor.Find(x => x.AuthorId == p.AuthorId);
			author.AboutShort = p.AboutShort;
			author.AuthorName = p.AuthorName;
			author.AuthorImage = p.AuthorImage;
			author.AuthorAbout = p.AuthorAbout;
			author.AuthorTitle = p.AuthorTitle;
			author.Password = p.Password;
			author.Mail = p.Mail;
			author.PhoneNumber = p.PhoneNumber;
			return repoAuthor.Update(author);
		}
	}
}
