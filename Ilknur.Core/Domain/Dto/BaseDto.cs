using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Core.Domain.Dto
{
    public class BaseDto
    {
        public int Id { get; set; }
    }

    public class NonTrackablePermanentDto : BaseDto
    {
        public bool? IsActive { get; set; }
    }

    public class TrackablePermanentDto : BaseDto
    {
        public string LastupUser { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class TrackableTransientDto : BaseDto
    {
        public string LastupUser { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }

}
