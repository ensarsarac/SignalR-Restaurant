using SignalREntityLayer.Entities;

namespace SignalRBusinessLayer.Abstract
{
	public interface IMenuTableService:IGenericService<MenuTable>
	{
		int TMenuTableCount();
	}
}
