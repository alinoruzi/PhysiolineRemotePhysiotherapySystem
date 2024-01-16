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
		
		public async Task<long> Add(ExerciseCategory exercise, CancellationToken cancellationToken)
			=> throw new NotImplementedException();
	}
}
