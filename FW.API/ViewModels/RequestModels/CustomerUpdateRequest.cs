namespace FW.API.ViewModels.RequestModels;

public record CustomerUpdateRequest(Guid Id, string Name, string Email, string Phone);
