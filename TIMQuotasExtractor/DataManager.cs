using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMQuotasExtractor
{
  public class Blueprint
  {
    private string bpSubTypeID;
    private string itemTypeID;
    private string itemSubTypeID;
    public string BpSubTypeID { get { return bpSubTypeID; } set { bpSubTypeID = value; } }
    public string ItemTypeID { get { return itemTypeID; } set { itemTypeID = value; } }
    public string ItemSubTypeID { get { return itemSubTypeID; } set { itemSubTypeID = value; } }

    public Blueprint()
    {
      bpSubTypeID = "";
      itemTypeID = "";
      itemSubTypeID = "";
    }
  }
  public class Item
  {
    private string typeID;
    private string subTypeID;
    public string TypeID { get { return typeID; } set { typeID = value; } }
    public string SubTypeID { get { return subTypeID; } set { subTypeID = value; } }

    public Item()
    {
      typeID = "";
      subTypeID = "";
    }
  }
}
