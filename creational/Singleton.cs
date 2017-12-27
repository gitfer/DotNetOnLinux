using System;

namespace Creational
{
    public class Cache
    {
    	protected Cache(){

    	}
    	private static Cache _instance;

    	public static Cache Instance()
    	{
    		if(_instance == null)
    		{
    			_instance = new Cache();
    		}
    		return _instance;
    	}
    }
}
