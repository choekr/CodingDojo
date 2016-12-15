using quotingdojoRedux.Models;
using System.Collections.Generic;
namespace quotingdojoRedux.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}