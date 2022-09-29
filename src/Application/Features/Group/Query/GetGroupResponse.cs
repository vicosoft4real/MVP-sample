namespace Application.Features.Group.Query;

public record GetGroupResponse
{
    public Guid Id { get; set; }
    public string Description { get;  set; }
    public string Code { get;  set; }
    public bool Active { get;  set; }
}