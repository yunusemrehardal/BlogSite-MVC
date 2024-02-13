using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager
	{
		Repository<Category> repocategory = new Repository<Category>();
		public List<Category> GetAll()
		{
			return repocategory.List();
		}
		public int CategoryAddBL(Category category)
		{
			if (category.CategoryName == "" || category.CategoryDescription == "" || category.CategoryName.Length <= 4 || category.CategoryName.Length >= 30)
			{
				return -1;
			}
			return repocategory.Insert(category);
		}
		public Category FindCategory(int id)
		{
			return repocategory.Find(x => x.CategoryId == id);
		}
		public int EditCategory(Category p)
		{
			Category category = repocategory.Find(x => x.CategoryId == p.CategoryId);
			if (p.CategoryName == "" | p.CategoryName.Length <= 2 | p.CategoryName.Length > 30)
			{
				return -1;
			}
			category.CategoryName = p.CategoryName;
			category.CategoryDescription = p.CategoryDescription;
			return repocategory.Update(category);
		}
		public int StatusFalseBL(int id)
		{
			Category category = repocategory.Find(x => x.CategoryId == id);
			category.CategoryStatus = false;
			return repocategory.Update(category);
		}
		public int StatusTrueBL(int id)
		{
			Category category = repocategory.Find(x => x.CategoryId == id);
			category.CategoryStatus = true;
			return repocategory.Update(category);
		}
	}
}
