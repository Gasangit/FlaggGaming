using System;
namespace FlaggGaming.Model.apiEpic;

public class Element
{
	public string title { get; set; }
	public string description { get; set; }
	List<KeyImage> keyImages { get; set; }
	public Seller seller { get; set; }
	public List<Category> categories { get; set; }
	public Price price { get; set; }

	public Element(){}
}
