using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DtoTypes
{
    public class DepartamentDto
    {
        public int Id { get; }
        public string Title { get; }

        public DepartamentDto(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }

}
