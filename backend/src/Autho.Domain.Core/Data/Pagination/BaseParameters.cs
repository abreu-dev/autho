using Autho.Domain.Core.Data.Pagination.Interfaces;

namespace Autho.Domain.Core.Data.Pagination
{
    public class BaseParameters : IParameters
    {
        private int _page = 0;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                value -= 1;
                _page = value < 0 ? 0 : value;
            }
        }

        private static int MaxSize => 30;

        private int _size = 10;
        public int Size
        {
            get 
            { 
                return _size; 
            }
            set 
            {
                if (value < 1)
                {
                    _size = 1;
                }
                else
                {
                    _size = value > MaxSize ? MaxSize : value;
                }
            }
        }

        public string? Order { get; set; }
    }
}
