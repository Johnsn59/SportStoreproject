using System;

namespace SportStore.Models.ViewModels
{
    public class PagingInfo
    {
        //   F i e l d s   &   P r o p e r t i e s

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }

        //   C o n s t r u c t o r s

        //   M e t h o d s
    }
}
