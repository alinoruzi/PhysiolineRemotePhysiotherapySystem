using Physioline.Framework.Domain;
using TreatmentManagement.Domain.Entities;

namespace TreatmentManagement.Domain.Repositories.ExerciseCategoryRepositories
{
	public interface IExerciseCategoryRepository : IBaseRepository<ExerciseCategory>
	{
		//Query:
		Task<ExerciseCategory> GetById(long id, CancellationToken cancellationToken);
		Task<bool> IsExistById(long id, CancellationToken cancellationToken);
		Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken);
		Task<List<ExerciseCategory>> GetAll(CancellationToken cancellationToken);
		Task<List<ExerciseCategory>> GetAllParents(CancellationToken cancellationToken);
		Task<List<ExerciseCategory>> GetChildrenById(long id, CancellationToken cancellationToken);
		Task<List<ExerciseCategory>> GetAllDeleted(CancellationToken cancellationToken);
		
		//Command:
		Task Create(ExerciseCategory exerciseCategory, CancellationToken cancellationToken);
		Task SaveChanges(CancellationToken cancellationToken);
	}
}
