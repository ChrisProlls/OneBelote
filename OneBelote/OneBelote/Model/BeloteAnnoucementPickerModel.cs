using System;
using System.Collections.Generic;
using System.Text;

namespace OneBelote.Model
{
    public class BeloteAnnouncementPickerModel
    {
        public string Label { get; set; }
        public BeloteAnnoucementEnum Announcement { get; set; }
    }

    public enum BeloteAnnoucementEnum
    {
        None,
        Them,
        Us
    }
}
