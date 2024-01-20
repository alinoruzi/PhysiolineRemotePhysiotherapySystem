using TreatmentManagement.Domain.Entities;
using TreatmentManagement.Domain.Repositories;
using TreatmentManagement.Domain.ServiceContracts;

namespace TreatmentManagement.DomainServices.DomainServices
{
	public class ExerciseService : IExerciseService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ExerciseService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Exercise> GetById(long id, CancellationToken cancellationToken)
			=> await _unitOfWork.ExerciseRepository.GetAsync(id, cancellationToken);
		
		public async Task<bool> IsExistById(long id, CancellationToken cancellationToken)
			=>  await _unitOfWork.ExerciseRepository
				.IsExistAsync(e=>e.Id==id, cancellationToken);
		public async Task<long> Add(Exercise entity,CancellationToken cancellationToken)
		{ 
			await _unitOfWork.ExerciseRepository.CreateAsync(entity,cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);
			return entity.Id;
		}
		public async Task<int> CommitChanges(CancellationToken cancellationToken)
			=> await _unitOfWork.CommitAsync(cancellationToken);
	}
}
