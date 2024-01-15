using TreatmentManagement.Application.Contracts.ExerciseServicesContracts.Commands;
using TreatmentManagement.Application.Contracts.ExerciseServicesContracts.DTOs;
using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories;
using TreatmentManagement.Domain.Repositories.ExerciseRepositories;
using TreatmentManagement.Domain.ValueObjects;

namespace TreatmentManagement.Application.Service.ExerciseServices.Commands
{
	public class AddGlobalExercise : IAddGlobalExercise
	{
		private readonly IExerciseRepository _exerciseRepository;
		private readonly IExerciseCategoryRepository _exerciseCategoryRepository;
		public AddGlobalExercise(IExerciseRepository exerciseRepository, IExerciseCategoryRepository exerciseCategoryRepository)
		{
			_exerciseRepository = exerciseRepository;
			_exerciseCategoryRepository = exerciseCategoryRepository;
		}

		public async Task<ExerciseOutputDto> Run(ExerciseInputDto inputDto, CancellationToken cancellationToken)
		{ 
			var exercise = new Exercise
			{
				Title = inputDto.Title,
				ShortDescription = inputDto.ShortDescription,
				LongDescription = inputDto.LongDescription,
				IsGlobal = true,
				CreatedAt = DateTime.Now,
				CreatorUserId = inputDto.CreatorUserId,
				IsDeleted = false
			};

			exercise = await _exerciseRepository.CreateAsync(exercise, cancellationToken);

			SetCategories(exercise, inputDto.ExerciseCategoriesId);
			SetGuideReferences(exercise, inputDto.GuideReferences);
			await _exerciseRepository.SaveChangesAsync(cancellationToken);


			var result = new ExerciseOutputDto()
			{
				Id = exercise.Id,
				Title = exercise.Title,
				ShortDescription = exercise.ShortDescription,
				LongDescription = exercise.LongDescription,
				CreatedAt = exercise.CreatedAt,
				IsGlobal = true,
				UserCreatorId = exercise.CreatorUserId,
				GuideReferences = exercise.GuideReferences.Select(g => new ExerciseGuidesReferenceDto()
				{
					Title = g.Title,
					Url = g.Url
				}).ToList(),
				CategoriesId = exercise.Categorizations.Select(c => c.ExerciseCategoryId).ToList()
			};

			return result;
		}

		private async Task SetCategories(Exercise exercise, List<long> categoriesId, CancellationToken cancellationToken)
		{
			foreach (var categoryId in categoriesId)
			{
				if (await _exerciseCategoryRepository.IsExistById(categoryId,cancellationToken))
					exercise.Categorizations.Add(new ExerciseCategorization()
					{
						ExerciseId = exercise.Id,
						ExerciseCategoryId = categoryId
					});
			}
		}

		private async Task SetStaticPicture()
		{
			
		}

		private void SetGuideReferences(Exercise exercise, List<ExerciseGuidesReferenceDto>? guides)
		{
			exercise.GuideReferences = new List<ExerciseGuideReference>();
			if (guides is not { Count: > 0 })
				return;
			
			foreach (var item in guides)
			{
				exercise.GuideReferences.Add(new ExerciseGuideReference()
				{
					Title = item.Title,
					Url = item.Url
				});
			}
			
		}
	}
}
