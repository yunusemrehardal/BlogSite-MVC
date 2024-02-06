using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentManager
	{
		Repository<Comment> repocomment = new Repository<Comment>();
		public List<Comment> CommentList()
		{
			return repocomment.List();
		}
		public List<Comment> CommentByBlog(int id)
		{
			return repocomment.List(x => x.BlogId == id);
		}
		public List<Comment> CommentByStatusTrue()
		{
			return repocomment.List(x => x.CommentStatus == true);
		}
		public List<Comment> CommentByStatusFalse()
		{
			return repocomment.List(x => x.CommentStatus == false);
		}
		public int CommentAdd(Comment comment)
		{
			if (comment.CommentText.Length <= 4 || comment.CommentText.Length >= 301 || comment.UserName == "" || comment.Mail == "" || comment.UserName.Length <= 2)
			{
				return -1;
			}
			return repocomment.Insert(comment);
		}
		public int CommentStatusChangeToFalse(int id)
		{
			Comment comment = repocomment.Find(x => x.CommentId == id);
			comment.CommentStatus = false;
			return repocomment.Update(comment);
		}
		public int CommentStatusChangeToTrue(int id)
		{
			Comment comment = repocomment.Find(x => x.CommentId == id);
			comment.CommentStatus = true;
			return repocomment.Update(comment);
		}
	}
}
