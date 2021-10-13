namespace Lishl.Core.Models
{
    public interface IBaseModel <T>
    {
        public T Id { get; set; }
    }
}