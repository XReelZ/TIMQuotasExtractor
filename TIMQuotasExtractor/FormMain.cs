using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TIMQuotasExtractor
{
  public partial class Main : Form
  {
    private string selectedFolder = "";
    public Main()
    {
      InitializeComponent();
    }

    private void btnSelectFolder_Click(object sender, EventArgs e)
    {
      LoadFolder();
    }
    private void btnExtractQuotas_Click(object sender, EventArgs e)
    {
      Execute();
    }

    private void LoadFolder()
    {
      if (dlgBrowse.ShowDialog(this) == DialogResult.OK)
      {
        selectedFolder = dlgBrowse.SelectedPath;
        lblSelectedFolder.Text = dlgBrowse.SelectedPath;
      }
      //else
      //{
      //  selectedFolder = "";
      //  lblSelectedFolder.Text = "";
      //}
    }
    private void Execute()
    {
      if (selectedFolder == "")
      {
        MessageBox.Show("Please select Space Engineers main folder.");
      }
      else
      {
        string dataFolder = selectedFolder + "\\Content\\Data";
        if (Directory.Exists(dataFolder))
        {
          string modsFolder = selectedFolder.Substring(0, selectedFolder.IndexOf("common\\")) + "workshop\\content\\244850";
          //
          List<string> blueprintFiles = new List<string>();
          List<string> componentFiles = new List<string>();
          List<string> ammoMagazineFiles = new List<string>();
          List<string> physcalItemFiles = new List<string>();
          //
          blueprintFiles.Add(dataFolder + "\\Blueprints.sbc");
          componentFiles.Add(dataFolder + "\\Components.sbc");
          ammoMagazineFiles.Add(dataFolder + "\\AmmoMagazines.sbc");
          physcalItemFiles.Add(dataFolder + "\\PhysicalItems.sbc");
          //
          if (Directory.Exists(modsFolder))
          {
            foreach (string folder in Directory.GetDirectories(modsFolder))
            {
              string modsDataFolder = folder + "\\Data";
              if (Directory.Exists(modsDataFolder))
              {
                string[] modDataFiles = Directory.GetFiles(modsDataFolder);
                foreach (string file in modDataFiles)
                {
                  string fName = Path.GetFileName(file);
                  if (fName.ToLower().Contains("blueprint"))
                    blueprintFiles.Add(modsDataFolder + "\\" + fName);
                  else if (fName.ToLower().Contains("components"))
                    componentFiles.Add(modsDataFolder + "\\" + fName);
                  else if (fName.ToLower().Contains("ammomagazines"))
                    ammoMagazineFiles.Add(modsDataFolder + "\\" + fName);
                  else if (fName.ToLower().Contains("physicalitems"))
                    physcalItemFiles.Add(modsDataFolder + "\\" + fName);
                }
              }
            }
          }
          //
          //if (!File.Exists(blueprints) || !File.Exists(ammoMagazines) || !File.Exists(physcalItems) || !File.Exists(components))
          //{
          //  MessageBox.Show("Missing required data structure, please reinstall Windows or contact someone smart :)\r\n JK you can contact the creator of this tool :P");
          //}
          //else
          {
            List<Blueprint> blueprintsList = new List<Blueprint>();
            List<Item> itemsList = new List<Item>();
            //
            ExtractQuotas(blueprintFiles, ammoMagazineFiles, physcalItemFiles, componentFiles, blueprintsList, itemsList);
            if (blueprintsList.Count > 0 && itemsList.Count > 0)
            {
              itemsList = itemsList.OrderBy(x => x.SubTypeID).ToList();
              //
              if (dlgSave.ShowDialog(this) == DialogResult.OK)
              {
                string ores = "Ore/\r\n";
                string ingots = "Ingot/\r\n";
                string componentsStr = "Component/\r\n";
                string magazines = "AmmoMagazine/\r\n";
                string physicalItemsStr = "PhysicalGunObject/\r\n";
                string gasContainerObjects = "GasContainerObject/\r\n";
                string oxygenContainerObjects = "OxygenContainerObject/\r\n";
                //
                string fName = dlgSave.FileName;
                foreach (Item item in itemsList)
                {
                  Blueprint blueprint = blueprintsList.SingleOrDefault(s => s.ItemSubTypeID == item.SubTypeID);
                  string bpSubTypeID = "";
                  string label = "";
                  if (blueprint != null)
                  {
                    if (item.SubTypeID != blueprint.BpSubTypeID)
                      bpSubTypeID = blueprint.BpSubTypeID;
                    //
                    if (bpSubTypeID.Length > 22)
                    {
                      label = bpSubTypeID;
                      label = label.Replace("Component", "");
                      label = label.Replace("Generator", "Gen");
                      label = label.Replace("Communication", "Comm");
                    }
                  }
                  //   
                  if (item.TypeID.ToUpper() == "ORE")
                    ores += "/" + item.SubTypeID + "\r\n";
                  //
                  if (item.TypeID.ToUpper() == "INGOT")
                    ingots += "/" + item.SubTypeID + ",0,0%\r\n";
                  //  
                  if (item.TypeID.ToUpper() == "AMMOMAGAZINE")
                    magazines += "/" + item.SubTypeID + ",0,0%,," + bpSubTypeID + "\r\n";
                  //
                  if (item.TypeID.ToUpper() == "GASCONTAINEROBJECT")
                    gasContainerObjects += "/" + item.SubTypeID + ",0,0%,," + bpSubTypeID + "\r\n";
                  //
                  if (item.TypeID.ToUpper() == "OXYGENCONTAINEROBJECT")
                    oxygenContainerObjects += "/" + item.SubTypeID + ",0,0%,," + bpSubTypeID + "\r\n";
                  //   
                  if (item.TypeID.ToUpper() == "COMPONENT")
                    componentsStr += "/" + item.SubTypeID + ",0,0%," + label + "," + bpSubTypeID + "\r\n";
                  //
                  if (item.TypeID.ToUpper() == "PHYSICALGUNOBJECT")
                    physicalItemsStr += "/" + item.SubTypeID + ",0,0%," + label + "," + bpSubTypeID + "\r\n";
                }
                //
                string content = magazines + "\r\n" + componentsStr + "\r\n" + gasContainerObjects + "\r\n" + ores + "\r\n" + ingots + "\r\n" + oxygenContainerObjects + "\r\n" + physicalItemsStr;
                File.WriteAllText(fName, content);
                MessageBox.Show("Success!");
              }
            }
          }
        }
        else
          MessageBox.Show("Can't find Data folder \r\nPlease select Space Engineers main folder.");
      }
    }
    private void ExtractQuotas(List<string> aBlueprints, List<string> aAmmoMagazines, List<string> aPhysicalItems, List<string> aComponents, List<Blueprint> aBlueprintsList, List<Item> aItemsList)
    {
      foreach (string blueprint in aBlueprints)
      {
        string blueprintsContent = File.ReadAllText(blueprint);
        ExtractBlueprints(blueprintsContent, aBlueprintsList);
      }
      //    
      foreach (string ammoMagazine in aAmmoMagazines)
      {
        string ammoMagazinesContent = File.ReadAllText(ammoMagazine);
        ExtractItemIDs(ammoMagazinesContent, "AMMOMAGAZINE", aItemsList);
      }
      //  
      foreach (string physicalItem in aPhysicalItems)
      {
        string physicalItemsContent = File.ReadAllText(physicalItem);
        ExtractItemIDs(physicalItemsContent, "PHYSICALITEM", aItemsList);
      }
      //
      // Scrap has special place in my heart as it is same as the others but different !!!!!!
      Item scrap = new Item();
      scrap.TypeID = "Ore";
      scrap.SubTypeID = "Scrap";
      aItemsList.Add(scrap);
      //  
      foreach (string component in aComponents)
      {
        string componentsContent = File.ReadAllText(component);
        ExtractItemIDs(componentsContent, "COMPONENT", aItemsList);
      }
    }
    private void ExtractBlueprints(string aSource, List<Blueprint> aBlueprints)
    {
      if(aBlueprints==null)
        aBlueprints = new List<Blueprint>();
      //
      XElement blueprintsXML = XElement.Parse(aSource);
      //
      foreach (XElement element in blueprintsXML.Elements())
      {
        if (element.Name.LocalName.ToUpper() == "BLUEPRINTS")
        {
          foreach (XElement blueprint in element.Elements())
          {
            if (blueprint.Name.LocalName.ToUpper() == "BLUEPRINT")
            {
              Blueprint bp = new Blueprint();
              //
              foreach (XElement bpChild in blueprint.Elements())
              {
                if (bpChild.Name.LocalName.ToUpper() == "ID")
                {
                  foreach (XElement id in bpChild.Elements())
                  {
                    if (id.Name.LocalName.ToUpper() == "SUBTYPEID")
                      bp.BpSubTypeID = id.Value;
                  }
                }
                if (bpChild.Name.LocalName.ToUpper() == "RESULT")
                {
                  foreach (var attribute in bpChild.Attributes())
                  {
                    if (attribute.Name.LocalName.ToUpper() == "SUBTYPEID")
                      bp.ItemSubTypeID = attribute.Value;
                    if (attribute.Name.LocalName.ToUpper() == "TYPEID")
                      bp.ItemTypeID = attribute.Value;
                  }
                }
              }
              if(bp.ItemTypeID.ToUpper()!="INGOT" && bp.ItemTypeID.ToUpper() != "")
                aBlueprints.Add(bp);
            }
          }
        }
      }
    }
    private void ExtractAmmoMagazines(string aSource, List<Item> aItems)
    {
      if (aItems == null)
        aItems = new List<Item>();
      XElement ammoMagazinesXML = XElement.Parse(aSource);
      //
      foreach (XElement element in ammoMagazinesXML.Elements())
      {
        if (element.Name.LocalName.ToUpper() == "AMMOMAGAZINES")
        {
          foreach (XElement ammoMagazine in element.Elements())
          {
            if (ammoMagazine.Name.LocalName.ToUpper() == "AMMOMAGAZINE")
            {
              Item ammo = new Item();
              bool canPlayerOrder = false;
              //
              foreach (XElement ammoChild in ammoMagazine.Elements())
              {
                if (ammoChild.Name.LocalName.ToUpper() == "ID")
                {
                  foreach (XElement id in ammoChild.Elements())
                  {
                    if (id.Name.LocalName.ToUpper() == "TYPEID")
                      ammo.TypeID = id.Value;
                    if (id.Name.LocalName.ToUpper() == "SUBTYPEID")
                      ammo.SubTypeID = id.Value;
                  }
                }

                if (ammoChild.Name.LocalName.ToUpper() == "CANPLAYERORDER")
                {
                  canPlayerOrder = ammoChild.Value.ToUpper() == "TRUE";
                }
              }
              if (canPlayerOrder)
                aItems.Add(ammo);
            }
          }
        }
      }
    }
    private void ExtractPhysicalItems(string aSource, List<Item> aItems)
    {
      if (aItems == null)
        aItems = new List<Item>();
      XElement ammoMagazinesXML = XElement.Parse(aSource);
      //
      foreach (XElement element in ammoMagazinesXML.Elements())
      {
        if (element.Name.LocalName.ToUpper() == "PHYSICALITEMS")
        {
          foreach (XElement xItem in element.Elements())
          {
            if (xItem.Name.LocalName.ToUpper() == "PHYSICALITEM")
            {
              Item item = new Item();
              bool canPlayerOrder = false;
              //
              foreach (XElement ammoChild in xItem.Elements())
              {
                if (ammoChild.Name.LocalName.ToUpper() == "ID")
                {
                  foreach (XElement id in ammoChild.Elements())
                  {
                    if (id.Name.LocalName.ToUpper() == "TYPEID")
                      item.TypeID = id.Value;
                    if (id.Name.LocalName.ToUpper() == "SUBTYPEID")
                      item.SubTypeID = id.Value;
                  }
                }

                if (ammoChild.Name.LocalName.ToUpper() == "CANPLAYERORDER")
                {
                  canPlayerOrder = ammoChild.Value.ToUpper() == "TRUE";
                }
              }
              if (canPlayerOrder)
                aItems.Add(item);
            }
          }
        }
      }
    }
    private void ExtractItemIDs(string aSource, string aTag, List<Item> aItems)
    {
      if (aTag.Trim() == "" || aSource.Trim() == "")
      {
        MessageBox.Show("Something went terribly wrong.\r\nPlease don't hate the creator!");
        return;
      }
      if (aItems == null)
        aItems = new List<Item>();
      XElement itemsXML = XElement.Parse(aSource);
      //
      foreach (XElement element in itemsXML.Elements())
      {
        if (element.Name.LocalName.ToUpper() == aTag.ToUpper()+"S")
        {
          foreach (XElement xItem in element.Elements())
          {
            if (xItem.Name.LocalName.ToUpper() == aTag.ToUpper())
            {
              Item item = new Item();
              bool canPlayerOrder = false;
              //
              foreach (XElement xItemChild in xItem.Elements())
              {
                if (xItemChild.Name.LocalName.ToUpper() == "ID")
                {
                  foreach (XElement id in xItemChild.Elements())
                  {
                    if (id.Name.LocalName.ToUpper() == "TYPEID")
                      item.TypeID = id.Value;
                    if (id.Name.LocalName.ToUpper() == "SUBTYPEID")
                      item.SubTypeID = id.Value;
                  }
                }

                if (xItemChild.Name.LocalName.ToUpper() == "CANPLAYERORDER")
                  canPlayerOrder = xItemChild.Value.ToUpper() == "TRUE";
              }
              if (canPlayerOrder)
                aItems.Add(item);
            }
          }
        }
      }
    }
  }
}
