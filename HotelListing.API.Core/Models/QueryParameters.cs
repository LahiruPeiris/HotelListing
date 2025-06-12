namespace HotelListing.API.Core.Models
{
    public class QueryParameters
    {
        private int _pageSize = 10;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize
        { 
            get { return _pageSize; }
            set {  _pageSize = value; }
        }

    }
}
