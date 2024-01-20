using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.DomainServices.DomainServices
{
	public class ExerciseCategoryService : IExerciseCategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ExerciseCategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ExerciseCategory> GetById(long id, CancellationToken cancellationToken)
			=> await _unitOfWork.ExerciseCategoryRepository.GetAsync(id, cancellationToken);

		public async Task<IEnumerable<ExerciseCategory>> GetAll(CancellationToken cancellationToken)
			=> await _unitOfWork.ExerciseCategoryRepository.GetAllAsync(cancellationToken);
		
		public async Task<bool> IsExistById(long id, CancellationToken cancellationToken)
			=> await _unitOfWork.ExerciseCategoryRepository
				.IsExistAsync((ec=>ec.Id == id),cancellationToken);
		public async Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken)
			=> await _unitOfWork.ExerciseCategoryRepository
				.IsExistAsync(ec=>ec.Title == title, cancellationToken);

		public async Task<long> Add(ExerciseCategory entity, CancellationToken cancellationToken)
		{
			await _unitOfWork.ExerciseCategoryRepository.CreateAsync(entity, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			return entity.Id;
		}
		public async Task<int> CommitChanges(CancellationToken cancellationToken)
			=> await _unitOfWork.CommitAsync(cancellationToken);
	}
}
