using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Queries
{
	public interface IGetCollectionCategoryAppService
	{
		Task<ValueResult<GetCollectionCategoryDto>> Run(long id,
			CancellationToken cancellationToken);
	}
}
