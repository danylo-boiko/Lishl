using System;

namespace Lishl.Core.Models
{
    public class LinkFollow : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string IpAddress { get; set; }
    }
}