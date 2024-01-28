namespace AccountManagement.Domain.Repositories
{
	public interface IUnitOfWork
	{
		public IUserRepository UserRepository { get; }
		public IAdminRepository AdminRepository { get; }
		public IExpertRepository ExpertRepository { get; }
		public IClientRepository ClientRepository { get; }
		public ISpecializedTitleRepository SpecializedTitleRepository { get; }

		Task<int> CommitAsync(CancellationToken cancellationToken);
	}
}
