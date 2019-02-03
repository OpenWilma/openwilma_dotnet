namespace Wilma.Api.Wilma
{
    public sealed class WilmaRole
    {
        public string Name { get; set; }
        public RoleType Type { get; set; }
        public int PrimusId { get; set; }
        public string FormKey { get; set; }
        public string Photo { get; set; }
        public bool EarlyEduUser { get; set; }
        public string Slug { get; set; }
        public string School { get; set; }

        public WilmaRole()
        { }
    }
}
