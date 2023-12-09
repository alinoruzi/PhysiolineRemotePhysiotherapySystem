using Microsoft.AspNetCore.Mvc;
using Physioline.EM.Application.Abstraction.CategoryServices.Commands;
using Physioline.EM.Application.Abstraction.CategoryServices.Queries;
using Physioline.WebApp.Areas.Administration.Models;

namespace Physioline.WebApp.Areas.Administration.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IGetCategoryListByAdmin _getCategoryList;
		private readonly IAddCategoryByAdmin _addCategory;
		private readonly IGetParentCategories _getParentCategories;
		public CategoryController(IAddCategoryByAdmin addCategory, IGetCategoryListByAdmin getCategoryList, IGetParentCategories getParentCategories)
		{
			_addCategory = addCategory;
			_getCategoryList = getCategoryList;
			_getParentCategories = getParentCategories;
		}

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var categoryDtos = await _getCategoryList.Execute(cancellationToken);

			var model = categoryDtos.Select(x => new CategoryItemViewModel()
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				CreatedAt = x.CreatedAt.ToString("yy-MM-dd"),
				Parent = x.Parent == null
					? null
					: new CategoryItemViewModel()
					{
						Id = x.Parent.Id,
						Title = x.Parent.Title,
						Description = x.Parent.Description,
						CreatedAt = x.Parent.CreatedAt.ToString("yy-MM-dd")
					}
			}).ToList();
			
			return View(model);
		}
		
		[HttpGet]
		public async Task<IActionResult> Create(CancellationToken cancellationToken)
		{
			ViewData["ParentCategories"] = await _getParentCategories.Execute(cancellationToken);
			return View(new CategoryCreateViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(CategoryCreateViewModel categoryCreateViewModel, CancellationToken cancellationToken)
		{
			var result = await _addCategory.Execute(categoryCreateViewModel.Title, categoryCreateViewModel.Description, categoryCreateViewModel.ParentId, 0,
				cancellationToken);
			if (!result.IsSuccess)
				throw new Exception("Error in Create Category by Admin Controller.");
			
			ViewData["ActionResult"] = true;
			ViewData["ActionName"] = "افزودن دسته بندی";
			ViewData["ActionObjectTitle"] = categoryCreateViewModel.Title;
			
			return RedirectToAction("Index");
		}
		
		[HttpGet]
		public IActionResult Edit(long Id)
		{
			return Ok();
		}
		
		[HttpPost]
		public IActionResult Delete(long Id)
		{
			return Ok();
		}
	}
}
